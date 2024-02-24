namespace Z2.Models;

public interface IBookService
{
    void Add(Book book);
    IEnumerable<Book> FindAll();
    void Delete(int id);
    void Edit(Book book);
    Book? FindById(int id);

    IEnumerable<Author> FindAllAuthors();
}