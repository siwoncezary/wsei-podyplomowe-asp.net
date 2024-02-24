using Microsoft.AspNetCore.Mvc;
using Z2.Models;

namespace Z2.Controllers;

public class SearchController : Controller
{
    // dodaj kod, który umożliwi dostęp do serwisu książek
    private readonly IBookService _service;

    public SearchController(IBookService service)
    {
        _service = service;
    }

    // GET
    public IActionResult Index(SearchModel model)
    {
        model.Result = new List<Book>();
        if (model.TitleQuery is not null && model.AuthorQuery is null)
        {
            model.Result = _service.FindAll()
                .Where(book => book.Title.StartsWith(model.TitleQuery))
                .ToList();
        }
        // przypadek szukania wg autora
        // if (model.AuthorQuery is not null && model.TitleQuery is null)
        // {
        //     model.Result = _service.FindAll()
        //         .Where(book => book.Author.StartsWith(model.AuthorQuery))
        //         .ToList();
        // }
        // if (model.AuthorQuery is not null && model.TitleQuery is not null)
        // {
        //     model.Result = _service.FindAll()
        //         .Where(book => book.Author.StartsWith(model.AuthorQuery) && book.Title.StartsWith(model.TitleQuery))
        //         .ToList();
        // }
        return View(model);
    }
}