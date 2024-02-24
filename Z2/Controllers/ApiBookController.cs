using Microsoft.AspNetCore.Mvc;
using Z2.Models;

namespace Z2.Controllers;

[ApiController]
[Route("/api/books")]
public class ApiBookController : ControllerBase
{
    private readonly IBookService _service;

    public ApiBookController(IBookService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<object> GetAll()
    {
        // return _service.FindAll().Select(b =>
        //     new
        //     {
        //         Id = b.Id,
        //         Title = b.Title,
        //         Author = $"{b.Author.FirstName} {b.Author.LastName}",
        //         ISBN = b.ISBN
        //     }
        //     ).ToList();
        return _service.FindAll().Select(b =>
            new
            {
                Id = b.Id,
                Title = b.Title,
                Author = new {Name= $"{b.Author?.FirstName} {b.Author?.LastName}", Email= b.Author?.Email},
                ISBN = b.ISBN
            }
            ).ToList();
    }
    // /api/books/id
    [Route("{id}")]
    public ActionResult<object> GetOne(int id)
    {
        var book = _service.FindById(id);
        if (book is null)
        {
            return NotFound();
        }
        return new
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.AuthorId,
            ISBN = book.ISBN
        };
    }
    
    // Zdefiniuj nowy kontroler API pracujący pod scieżką /api/authors
    // zdefiniuj metodę zwracającą autora o podanym id np. /api/authors/1
    // do kontrolera wstrzyknij AppDbContext, żeby znaleźć wybranego autora
}