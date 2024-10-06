using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.DataAccess.Repositories;
using Library.Domain.Models;

public class BookInstanceService : IBookInstanceService
{
    private readonly IBookInstanceRepository _bookInstanceRepository;

    public BookInstanceService(IBookInstanceRepository bookInstanceRepository)
    {
        _bookInstanceRepository = bookInstanceRepository;
    }

    // Получение всех экземпляров книг
    public async Task<List<BookInstance>> GetAllBookInstances()
    {
        return await _bookInstanceRepository.GetAll();
    }

    // Получение экземпляра книги по ID
    public async Task<BookInstance> GetBookInstanceById(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Invalid book instance ID.", nameof(id));
        return await _bookInstanceRepository.GetById(id); 
    }

    // Добавление нового экземпляра книги
    public async Task<Guid> AddBookInstance(BookInstance bookInstance)
    {
        if (bookInstance == null) throw new ArgumentNullException(nameof(bookInstance));
        return await _bookInstanceRepository.Add(bookInstance);
    }

    // Обновление экземпляра книги
    public async Task<Guid> UpdateBookInstance(BookInstance bookInstance)
    {
        if (bookInstance == null) throw new ArgumentNullException(nameof(bookInstance));
        return await _bookInstanceRepository.Update(bookInstance);
    }

    // Удаление экземпляра книги по ID
    public async Task<Guid> DeleteBookInstance(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Invalid book instance ID.", nameof(id));
        return await _bookInstanceRepository.Delete(id);
    }
}
