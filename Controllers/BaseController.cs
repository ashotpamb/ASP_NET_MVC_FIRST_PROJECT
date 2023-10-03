using CherryShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CherryShop.Controllers;

public class BaseController : Controller
{
    public readonly DatabaseContext _context; 
    public BaseController(DatabaseContext context)
    {
        _context = context;
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if(context.HttpContext.Items.TryGetValue("Layout", out var layout))
        {
            ViewData["Layout"] = context.HttpContext.Items["Layout"]?.ToString();
        }
        base.OnActionExecuting(context);
    }
}