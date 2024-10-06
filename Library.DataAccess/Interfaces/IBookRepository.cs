using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();
        Task<Book> GetById(Guid id);
        Task<Book> GetByISBN(string isbn);
        Task<Guid> Add(Book book);
        Task<Guid> Update(Book book);
        Task<Guid> Delete(Guid id);
    }
}
