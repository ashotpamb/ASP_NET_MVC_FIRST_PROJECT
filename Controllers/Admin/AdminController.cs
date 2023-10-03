using CherryShop.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CherryShop.Controllers.Admin;

public class Admin : BaseController
{
    public Admin(DatabaseContext context) : base(context)
    {
    }

    public IActionResult Index()
    {
        return View();
    }

}