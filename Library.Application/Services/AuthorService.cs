using Library.DataAccess.Interfaces;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<List<Author>> GetAuthors()
    {
        return await _authorRepository.GetAll();
    }

    public async Task<Author> GetAuthor(Guid id)
    {
        return await _authorRepository.GetById(id);
    }

    public async Task<Guid> AddAuthor(Author author)
    {
        Console.WriteLine($"Сервис {author.Id} {author.FirstName}");
        return await _authorRepository.Add(author);
    }

    public async Task<Guid> UpdateAuthor(Author author)
    {
        return await _authorRepository.Update(author);
    }

    public async Task<Guid> DeleteAuthor(Guid id)
    {
        return await _authorRepository.Delete(id);
    }
}
