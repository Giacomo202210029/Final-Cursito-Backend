using ExamenFinalCursitoBackend.BookShop.DataAccess.Models;
using ExamenFinalCursitoBackend.BookShop.DataAccess.Repositories;

namespace ExamenFinalCursitoBackend.BookShop.Services;

public class BookService : IBookService
{
    //todo aqui van las validaciones 
    private readonly IBookRepository _bookRepository;
    
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    
    public void AddBook(Book book)
    {
        _bookRepository.Create(book);
    }

    public void UpdateBook(Book book)
    {
        _bookRepository.Update(book);
    }

    public void DeleteBook(int id)
    {
        _bookRepository.Delete(id);
    }

    public Book GetBookById(int id)
    {
        return _bookRepository.GetById(id);
    }
}