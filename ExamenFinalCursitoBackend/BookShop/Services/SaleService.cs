using ExamenFinalCursitoBackend.BookShop.DataAccess.Models;
using ExamenFinalCursitoBackend.BookShop.DataAccess.Repositories;

namespace ExamenFinalCursitoBackend.BookShop.Services;

public class SaleService : ISaleService
{
    private readonly ISaleRepository _saleRepository;
    
    public SaleService(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }
    
    public void AddSale(Sale sale)
    {
        _saleRepository.Create(sale);
    }

    public Sale GetSaleById(int id)
    {
        return _saleRepository.GetById(id);
    }
}