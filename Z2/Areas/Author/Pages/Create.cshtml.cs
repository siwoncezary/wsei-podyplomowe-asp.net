using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Z2.Areas.Author.Pages;

public class Create : PageModel
{

    [BindProperty] 
    public  Model.Author Author { get; set; }
    
    public void OnGet()
    {
        Author = new Model.Author() { FirstName = "", LastName = "" };
    }

    public IActionResult OnPost()
    {
        return RedirectToAction("Index","Book");
    }
}