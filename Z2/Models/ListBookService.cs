namespace Z2.Models;

public class ListBookService: IBookService
{
    private readonly List<Book> _books = new ()
    {
        new()
        {
            Id = 1, 
            Title = "C#", 
            Pages = 1023, 
            Published = new DateOnly(2023,10,10),
            ISBN = "7382992243534"
        },
        new()
        {
            Id = 2, 
            Title = "ASP.NET", 
            Pages = 7843, 
            Published = new DateOnly(2023,11,23),
            ISBN = "7382672243534"
        }
    };
    private int _id = 2;

    public void Add(Book book)
    {
        book.Id = ++_id;
        _books.Add(book);
    }

    public IEnumerable<Book> FindAll()
    {
        return _books;
    }

    public void Delete(int id)
    {
        Book? bookToDelete = FindById(id);
        if (bookToDelete is not null)
        {
            _books.Remove(bookToDelete);
        }
    }

    public void Edit(Book book)
    {
        Book? bookToEdit = FindById(book.Id);
        if (bookToEdit is not null)
        {
            _books.Remove(bookToEdit);
            _books.Add(book);
        }
        
    }

    public Book? FindById(int id)
    {
        return _books
            .FirstOrDefault(book => book.Id == id);
    }
}