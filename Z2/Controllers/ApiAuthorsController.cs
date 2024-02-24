using Microsoft.AspNetCore.Mvc;
using Z2.Data;
using Z2.Models;

namespace Z2.Controllers;
[ApiController]
[Route("/api/authors")]
public class ApiAuthorsController: ControllerBase
{
    private readonly AppDbContext _context;

    public ApiAuthorsController(AppDbContext context)
    {
        _context = context;
    }

    [Route("{id}")]
    public ActionResult<Author> GetOne(int id)
    {
        var author = _context.Authors.Find(id);
        if (author is null)
        {
            return NotFound();
        }
        return author;
    }

    [HttpPost]
    public ActionResult Add(AuthorDto author)
    {
        var entityEntry = _context.Authors.Add(
            new Author()
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                Email = author.Email
            }
            );
        _context.SaveChanges();
        return Created($"/api/authors/{entityEntry.Entity.Id}", entityEntry.Entity);
    }
}