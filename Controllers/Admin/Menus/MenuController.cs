using CherryShop.Data;
using CherryShop.Models.Header;
using CherryShop.Models.Menus;
using Microsoft.AspNetCore.Mvc;

namespace CherryShop.Controllers.Admin.Menus;

public class MenuController : BaseController
{
    public MenuController(DatabaseContext context) : base(context)
    {
    }

    [HttpGet("admin/menus")]
    public IActionResult Index()
    {
        List<Menu> menus = _context.Menus.ToList();

        return View("~/Views/Admin/Menus/Index.cshtml", menus);
    }

    [HttpGet("admin/new-menu")]
    public IActionResult Create()
    {
        return View("~/Views/Admin/Menus/Form.cshtml");
    }

    [HttpGet("admin/menu-edit")]
    public IActionResult Edit(int Id)
    {
        Menu? menus = _context.Menus.Where(m => m.Id == Id).FirstOrDefault();
        return View("~/Views/Admin/Menus/Edit.cshtml", menus);
    }

    public IActionResult Store(Menu menu)
    {

        _context.Menus.Add(menu);
        _context.SaveChanges();
        return Redirect("/admin/menus");
    }

    public IActionResult Update(Menu menu, int Id)
    {
        Menu? existingMenu = _context.Menus.FirstOrDefault(m => m.Id == Id);

        if (existingMenu == null)
        {
            return NotFound();
        }

        existingMenu.Name = menu.Name;
        existingMenu.Url = menu.Url;
        _context.SaveChanges();

        return Redirect("/admin/menus");
    }

    public IActionResult GetMenus()
    {
        var menus = _context.Menus.ToList();
        var viewModel = new HeaderView { Menus = menus };

        return PartialView("~/Views/Includes/_header.cshtml", viewModel);
    }

    [HttpGet("admin/menu-delete")]
    public IActionResult Remove(int Id)
    {
        var menu = _context.Menus.FirstOrDefault(f => f.Id == Id);

        if (menu != null)
        {
            _context.Menus.Remove(menu);
            _context.SaveChanges();
        }
        return Redirect("/admin/menus");

    }
}