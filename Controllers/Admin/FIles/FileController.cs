using CherryShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace CherryShop.Controllers.Admin.Files;

public class FileController : BaseController
{
    public readonly IWebHostEnvironment _env;
    public FileController(DatabaseContext context, IWebHostEnvironment env) : base(context)
    {
        _env = env;
    }

    public IActionResult Index()
    {
        List<CherryShop.Models.Files.File> _files = _context.Files.ToList();
        return View("~/Views/Admin/File/Index.cshtml", _files);
    }

    [HttpGet("/admin/upload")]
    public IActionResult Upload()
    {
        return View("~/Views/Admin/File/Form.cshtml");
    }

    [HttpPost]
    public IActionResult Store(IFormFile formFile, CherryShop.Models.Files.File file)
    {
        if (formFile != null && formFile.Length > 0)
        {
            var filePath = Path.Combine(_env.WebRootPath, "Storage/Files", formFile.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
            file.storagePath = filePath;
            file.name = formFile.FileName;
            file.Path = $"{Request.Scheme}://{Request.Host.Value}/Storage/Files/{formFile.FileName}";
            file.Type = formFile.ContentType;
            _context.Files.Add(file);
            _context.SaveChanges();
        }
        return Redirect("/admin/file");
    }

    public IActionResult Remove(int Id)
    {
        var file = _context.Files.FirstOrDefault(f => f.Id == Id);

        if (file != null)
         {
            System.IO.File.Delete(file.storagePath);
            _context.Files.Remove(file);
            _context.SaveChanges();
         }
        return Redirect("/admin/file");

    }
}