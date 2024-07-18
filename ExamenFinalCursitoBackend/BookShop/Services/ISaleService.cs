using ExamenFinalCursitoBackend.BookShop.DataAccess.Models;

namespace ExamenFinalCursitoBackend.BookShop.Services;

public interface ISaleService
{
    public void AddSale(Sale sale);
    
    public Sale GetSaleById(int id);
}