using CherryShop.Data;
using CherryShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace CherryShop.Controllers;

public class ContactController : BaseController
{
    public ContactController(DatabaseContext context) : base(context)
    {
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Check(Contact contact)
    {
        if (ModelState.IsValid)
        {
            return Redirect("/");
        }
        return View("Index");
    }
}