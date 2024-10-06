using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByUsernameAsync(string username);
        Task<List<BookInstance>> GetBookInstancesByUserIdAsync(Guid id);
        Task<Guid> AddAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(Guid id);
    }
}
