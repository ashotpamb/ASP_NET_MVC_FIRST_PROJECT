using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CherryShop.Data;
using CherryShop.Models.Products;
using CherryShop.Models.HomwViewModel;
using CherryShop.Models;
using Microsoft.EntityFrameworkCore;
using CherryShop.Services.Rabbit;

namespace CherryShop.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, DatabaseContext context) : base(context)
    {
        _logger = logger;
    }


    public IActionResult Index()
    {
        // Console.WriteLine(4655);
        // RabbitMqService rabbitMqService = new RabbitMqService();
        // rabbitMqService.SendAndReceiveMessage();
        // string response = await rabbitMqService.getReplayMessage();
        // Console.WriteLine($"Received response: {response}");

        List<Product> products = _context.Products.Include(r => r.FileReferences).ThenInclude(f => f.File).ToList();
        List<CherryShop.Models.Slider.Slider> slides = _context.Slides.Include(f => f.FileReferences).ThenInclude(file => file.File).ToList();
        ModelsForHome models = new ModelsForHome { Products = products, Slides = slides };
        return View(models);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
