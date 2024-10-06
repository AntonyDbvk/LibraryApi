using Library.DataAccess.Interfaces;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _context;

        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAll()
        {
            return await _context.Authors
                .Include(a => a.Books)
                .ToListAsync();
        }

        public async Task<Author> GetById(Guid id)
        {
            return await _context.Authors
                .Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Guid> Add(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author == null) throw new Exception("Author not found.");
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return author.Id;
        }

        public async Task<Guid> Update(Author newAuthor)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == newAuthor.Id);
            if (author == null) throw new Exception("Author not found.");
            _context.Entry(author).CurrentValues.SetValues(newAuthor);
            await _context.SaveChangesAsync();
            return author.Id;
        }
    }
}
