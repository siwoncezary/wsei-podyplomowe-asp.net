using Microsoft.AspNetCore.Mvc;
using Z1.Models;

namespace Z1.Controllers;

public class CalculatorController: Controller
{
    // Akcja zwracjąca formularz
    public IActionResult Calc()
    {
        return View();
    }

    [HttpPost]
    // Akcja odbierająca dane z formularza
    public IActionResult Calc(Calculator model)
    {
        if (ModelState.IsValid)
        {
            ViewBag.Result = model.Calculate().ToString();
            return View("Result");
        }
        return View();      // ponownie wyświetlamy formularz "Calc", jeśli są błędy walidacji
    }
    
}