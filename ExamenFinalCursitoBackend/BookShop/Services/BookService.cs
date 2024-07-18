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
        if (string.IsNullOrEmpty(book.Title))
        {
            throw new ArgumentException("El título es obligatorio");
        }

        if (string.IsNullOrEmpty(book.Author))
        {
            throw new ArgumentException("El autor es obligatorio");
        }

        if (string.IsNullOrEmpty(book.Isbn))
        {
            throw new ArgumentException("El ISBN es obligatorio");
        }

        if (string.IsNullOrEmpty(book.Genre))
        {
            throw new ArgumentException("El género es obligatorio");
        }


        if (book.Price <= 0)
        {
            throw new ArgumentException("El precio debe ser mayor que 0");
        }

        _bookRepository.Create(book);
    }

    public void UpdateBook(Book book)
    {
        if (string.IsNullOrEmpty(book.Title))
        {
            throw new ArgumentException("El título es obligatorio");
        }

        if (string.IsNullOrEmpty(book.Author))
        {
            throw new ArgumentException("El autor es obligatorio");
        }

        if (string.IsNullOrEmpty(book.Isbn))
        {
            throw new ArgumentException("El ISBN es obligatorio");
        }

        if (string.IsNullOrEmpty(book.Genre))
        {
            throw new ArgumentException("El género es obligatorio");
        }


        if (book.Price <= 0)
        {
            throw new ArgumentException("El precio debe ser mayor que 0");
        }
        _bookRepository.Update(book);
    }

    public void DeleteBook(int id)
    {
        var book = _bookRepository.GetById(id);
        if (book == null)
        {
            throw new ArgumentException("El libro con el ID especificado no existe");
        }
        _bookRepository.Delete(id);
    }

    public Book? GetBookById(int id)
    {
        return _bookRepository.GetById(id);
    }
}