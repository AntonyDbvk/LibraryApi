using Library.Domain.Models;

namespace Library.DataAccess.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Guid> Add(Author author);
        Task<Guid> Delete(Guid id);
        Task<List<Author>> GetAll();
        Task<Author> GetById(Guid id);
        Task<Guid> Update(Author newAuthor);
    }
}