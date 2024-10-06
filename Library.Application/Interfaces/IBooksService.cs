using Library.Domain.Models;

public interface IBooksService
{
    Task<Guid> AddBook(Book book);
    Task<Guid> DeleteBook(Guid id);
    Task<List<Book>> GetAllBooks();
    Task<Book> GetBook(Guid id);
    Task<Book> GetBookByISBN(string isbn);
    Task<Guid> UpdateBook(Book book);
}