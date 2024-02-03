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

    public string Hello()
    {
        if (Request.Query.TryGetValue("name", out var value))
        {
            return $"Hello {value}";
        }
        return "Hello";
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}