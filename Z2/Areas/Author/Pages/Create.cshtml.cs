using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Z2.Areas.Author.Pages
{

    public class Create : PageModel
    {
        // Model widoku formularza
        public class Author
        {
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
        }
        
        [BindProperty] 
        public Author Input { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // model encji utworzonej na podstawie modelu widoku
                var authorEntity = new Model.Author()
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = Input.FirstName,
                    LastName = Input.LastName
                };
                // tu powinien znaleźć się kod zapisania w aplikacji autora
                
                // Przykładowe przekierowanie do kontrolere i metody
                return RedirectToAction("Index", "Book");
            }
            // zwrócenie bieżącego widoku RazorPage, czyli formularza Create z komunikatami błędów  
            return Page();
        }
    }
}