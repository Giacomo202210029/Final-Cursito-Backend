using ExamenFinalCursitoBackend.BookShop.DataAccess.Models;

namespace ExamenFinalCursitoBackend.BookShop.Services;

public interface IBookService
{
    public void AddBook(Book book);
    
    public void UpdateBook(Book book);
    
    public void DeleteBook(int id);
    
    public Book? GetBookById(int id);
}