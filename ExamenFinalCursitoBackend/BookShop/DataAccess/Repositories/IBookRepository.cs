using ExamenFinalCursitoBackend.BookShop.DataAccess.Models;

namespace ExamenFinalCursitoBackend.BookShop.DataAccess.Repositories;

public interface IBookRepository
{
    public void Create(Book book);
    
    public void Update(Book book);
    
    public void Delete(int id);
    
    public Book GetById(int id);
    
}