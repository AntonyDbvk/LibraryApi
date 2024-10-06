using Library.Domain.Models;

public interface IAuthorService
{
    Task<Guid> AddAuthor(Author author);
    Task<Guid> DeleteAuthor(Guid id);
    Task<Author> GetAuthor(Guid id);
    Task<List<Author>> GetAuthors();
    Task<Guid> UpdateAuthor(Author author);
}
