using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.DataAccess.Interfaces;
using Library.Domain.Models;
using Microsoft.AspNetCore.Identity;

public class BooksService : IBooksService
{
    private readonly IBookRepository _bookRepository;

    public BooksService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    
    public async Task<List<Book>> GetAllBooks()
    {
        return await _bookRepository.GetAll();
    }

    public async Task<Book> GetBook(Guid id)
    {
        return await _bookRepository.GetById(id);
    }

    public async Task<Guid> AddBook(Book book)
    {
        if (book == null) throw new ArgumentNullException(nameof(book));
        return await _bookRepository.Add(book);
    }

    public async Task<Guid> UpdateBook(Book book)
    {
        if (book == null) throw new ArgumentNullException(nameof(book));
        return await _bookRepository.Update(book);
    }

    public async Task<Guid> DeleteBook(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Invalid book ID.", nameof(id));
        return await _bookRepository.Delete(id);
    }

    public async Task<Book> GetBookByISBN(string isbn)
    {
        return await _bookRepository.GetByISBN(isbn);
    }
}
