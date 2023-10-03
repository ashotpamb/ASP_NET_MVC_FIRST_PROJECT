using CherryShop.Data;
using CherryShop.Middlewares.FileProduct.FileReference;
using CherryShop.Models.FileProduct;
using CherryShop.Models.Slider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CherryShop.Controllers.Admin.Slides;

public class SlidesController : BaseController
{
    public SlidesController(DatabaseContext context) : base(context)
    {
        
    }

    [HttpGet("admin/slides")]
    public IActionResult Index()
    {
        List<Slider> slides = _context.Slides.ToList();

        return View("~/Views/Admin/Slides/Index.cshtml", slides);
    }

    [HttpGet("admin/new-slider")]
    public IActionResult Create()
    {
        List<CherryShop.Models.Files.File> _files = _context.Files.ToList();
        var fileProduct = new FileProduct<Slider>
        {
            File = _files,
            TProduct = new Slider()
        };
        return View("~/Views/Admin/Slides/Form.cshtml",fileProduct);
    }

    [HttpGet("admin/slider-delete")]
    public IActionResult Delete(int Id)
    {
        var slider = _context.Slides.Include(f => f.FileReferences)
        .ThenInclude(fi => fi.File)
        .FirstOrDefault(s => s.Id == Id);

        _context.Slides.Remove(slider);
        _context.SaveChanges();

        return Redirect("/admin/slides");
    }

    [HttpGet("admin/slider-edit")]
    public IActionResult Edit(int Id)
    {
        var slides = _context.Slides.Include(f => f.FileReferences).ThenInclude(f => f.File).FirstOrDefault();
        var fileProduct = new FileProduct<Slider>
        {
            File = slides.FileReferences.Select(f => f.File).ToList(),
            TProduct = slides
        };
        return View("~/Views/Admin/Slides/Edit.cshtml", fileProduct);
    }

    public IActionResult Store(Slider slider, string file_ids)
    {
        var selectedFilesIds = file_ids.Split(',').Select(int.Parse).ToArray();

        var selectedFiles = _context.Files.Where(f => selectedFilesIds.Contains(f.Id)).ToList();


        var _slider = new Slider
        {
            Title = slider.Title,
            Description = slider.Description,
            FileReferences = new List<FileReference>()
        };

        if (selectedFilesIds != null && selectedFilesIds.Length > 0)
        {
            foreach (var fileId in selectedFilesIds)
            {
                var fileReference = new FileReference
                {
                    ReferenceId = _slider.Id,
                    ReferenceType = "slider",
                    FileId = fileId

                };
                slider.FileReferences.Add(fileReference);
            }
        }

        _context.Slides.Add(_slider);
        _context.SaveChanges();
        return Redirect("/admin/slides");
    }

    // public IActionResult Update(Menu menu, int Id)
    // {
    //     Menu? existingMenu = _context.Menus.FirstOrDefault(m => m.Id == Id);

    //     if (existingMenu == null)
    //     {
    //         return NotFound();
    //     }

    //     existingMenu.Name = menu.Name;
    //     existingMenu.Url = menu.Url;
    //     _context.SaveChanges();

    //     return Redirect("/admin/menus");
    // }
}