using ExamenFinalCursitoBackend.BookShop.DataAccess.Models;

namespace ExamenFinalCursitoBackend.BookShop.DataAccess.Repositories;

public interface ISaleRepository
{
    public void Create(Sale sale);
    
    public Sale GetById(int id);
}