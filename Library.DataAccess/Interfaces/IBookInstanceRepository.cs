using Library.Domain.Models;

namespace Library.DataAccess.Repositories
{
    public interface IBookInstanceRepository
    {
        Task<Guid> Add(BookInstance bookInstance);
        Task<Guid> Delete(Guid id);
        Task<List<BookInstance>> GetAll();
        Task<BookInstance> GetById(Guid id);
        Task<Guid> Update(BookInstance bookInstance);
    }
}