using Z2.Models;

namespace Z2.Data;

public class EFBookService: IBookService
{
    private readonly AppDbContext _context;

    public EFBookService(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public IEnumerable<Book> FindAll()
    {
        return _context.Books.ToList();
    }

    public void Delete(int id)
    {
        var find = _context.Books.Find(id);
        if (find != null) _context.Books.Remove(find);
        _context.SaveChanges();
    }

    public void Edit(Book book)
    {
        _context.Update(book);
        _context.SaveChanges();
    }

    public Book? FindById(int id)
    {
        return _context.Books.Find(id);
    }
}