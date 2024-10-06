using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public class BookInstanceRepository : IBookInstanceRepository
    {
        private readonly LibraryContext _context;

        public BookInstanceRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<BookInstance>> GetAll()
        {
            return await _context.BookInstances
                        .Include(b => b.Book)
                        .Include(b => b.User)
                        .ToListAsync();
        }

        public async Task<BookInstance> GetById(Guid id)
        {
            return await _context.BookInstances
                        .Include(b => b.Book)
                        .Include(b => b.User)
                        .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Guid> Add(BookInstance bookInstance)
        {
            _context.BookInstances.Add(bookInstance);
            await _context.SaveChangesAsync();
            return bookInstance.Id;
        }

        public async Task<Guid> Update(BookInstance bookInstance)
        {
            var existingBookInstance = await _context.BookInstances.FindAsync(bookInstance.Id);
            if (existingBookInstance == null)
            {
                throw new ArgumentException("BookInstance not found.");
            }

            _context.Entry(existingBookInstance).CurrentValues.SetValues(bookInstance);
            await _context.SaveChangesAsync();
            return bookInstance.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            var bookInstance = await _context.BookInstances.FindAsync(id);
            if (bookInstance == null)
            {
                throw new ArgumentException("BookInstance not found.");
            }

            _context.BookInstances.Remove(bookInstance);
            await _context.SaveChangesAsync();
            return id;
        }
    }
}
