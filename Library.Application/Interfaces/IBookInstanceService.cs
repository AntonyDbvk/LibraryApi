using Library.Domain.Models;

public interface IBookInstanceService
{
    Task<Guid> AddBookInstance(BookInstance bookInstance);
    Task<Guid> DeleteBookInstance(Guid id);
    Task<List<BookInstance>> GetAllBookInstances();
    Task<BookInstance> GetBookInstanceById(Guid id);
    Task<Guid> UpdateBookInstance(BookInstance bookInstance);
}