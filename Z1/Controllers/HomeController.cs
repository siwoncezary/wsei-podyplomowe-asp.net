using System.Buffers;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Z1.Models;

namespace Z1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    // dodaj pobranie drugiego parametru z query o nazwie age
    // /home/hello?name=Adam&age=23
    public string Hello()
    {
        if (Request.Query.TryGetValue("name", out var value) && Request.Query.TryGetValue("age", out var age))
        {
            if (int.TryParse(age, out int intAge))
            {
                return $"Hello {value}, age {intAge}";
            }
            else
            {
                Response.StatusCode = 400;
                return "Age parameter is not a number!";
            }
        }
        return "Hello";
    }

    public IActionResult Welcome(string? name, int? age)
    {
        if (name is null || age is null)
        {
            return BadRequest();
            
        }
        ViewBag.HelloMessage = "Hello {name}, age {age}"; 
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}