using CherryShop.Data;
using CherryShop.Middlewares.FileProduct.FileReference;
using CherryShop.Models.FileProduct;
using CherryShop.Models.Products;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace CherryShop.Controllers.Admin;

public class ProductsController : BaseController
{
    public ProductsController(DatabaseContext context) : base(context)
    {
    }

    public IActionResult Index()
    {
        List<Product> products = _context.Products.Include(p => p.FileReferences).ThenInclude(file => file.File).ToList();

        return View("~/Views/Admin/Products/Index.cshtml", products);
    }

    public IActionResult New()
    {
        List<CherryShop.Models.Files.File> _files = _context.Files.ToList();
        var fileProduct = new FileProduct<Product>
        {
            File = _files,
            TProduct = new Product()
        };
        return View("~/Views/Admin/Products/Form.cshtml", fileProduct);
    }

    [HttpGet("/admin/product-edit")]
    public IActionResult Edit(int Id)
    {
        var product = _context.Products
            .Include(p => p.FileReferences)
            .ThenInclude(fr => fr.File)
            .FirstOrDefault(p => p.Id == Id);

        if (product == null)
        {
            return NotFound();
        }

        var fileProduct = new FileProduct<Product>
        {
            TProduct = product,
            File = product.FileReferences?.Select(fr => fr.File).ToList()
        };
        return View("~/Views/Admin/Products/Edit.cshtml", fileProduct);
    }

    [HttpGet("/admin/product-delete")]
    public IActionResult Delete(int Id)
    {
        var product = _context.Products
            .Include(p => p.FileReferences)
            .ThenInclude(fr => fr.File)
            .FirstOrDefault(p => p.Id == Id);

        if (product == null)
        {
            return NotFound();
        }

        _context.Remove(product);
        _context.SaveChanges();

        return Redirect("/admin/products");

    }


    public IActionResult Store(Product product, string file_ids)
    {
        var selectedFilesIds = file_ids.Split(',').Select(int.Parse).ToArray();

        var selectedFiles = _context.Files.Where(f => selectedFilesIds.Contains(f.Id)).ToList();


        var _product = new Product
        {
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            FileReferences = new List<FileReference>()
        };

        if (selectedFilesIds != null && selectedFilesIds.Length > 0)
        {
            foreach (var fileId in selectedFilesIds)
            {
                var fileReference = new FileReference
                {
                    ReferenceId = product.Id,
                    ReferenceType = "Product",
                    FileId = fileId

                };
                product.FileReferences.Add(fileReference);
                _context.SaveChanges();
            }
        }

        _context.Products.Add(product);
        _context.SaveChanges();
        return Redirect("/admin/products");
    }
}