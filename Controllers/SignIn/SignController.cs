using System.Text.Json.Serialization;
using CherryShop.Data;
using CherryShop.Services.Rabbit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CherryShop.Controllers.SignIn;

public class SignIn : BaseController
{
    public SignIn(DatabaseContext context) :base(context) {}
    [HttpGet("sign-in")]
    public IActionResult index()
    {
        return View("~/Views/Sign/_index.cshtml");
    }

    public void Register()
    {
        string? email = Request.Form["email"];
        string? password = Request.Form["password"];
        // string data = email+"~"+password;

        var data = new {Email = email, Password = password};

        string userData = JsonConvert.SerializeObject(data);

        Console.WriteLine(data);
        RabbitMqService service = new RabbitMqService("register", "regiterReplay", userData);
        service.SendAndReceiveMessage((replayMessage) => {
            Console.WriteLine(replayMessage);
        });
        Console.WriteLine("adfadfda");
    }
}