using ExamenFinalCursitoBackend.BookShop.DataAccess.Models;
using ExamenFinalCursitoBackend.BookShop.DataAccess.Repositories;

namespace ExamenFinalCursitoBackend.BookShop.Services;

public class SaleService : ISaleService
{
    private readonly ISaleRepository _saleRepository;
    private readonly ICustomerRepository _customerRepository;
    
    public SaleService(ISaleRepository saleRepository, ICustomerRepository customerRepository)
    {
        _saleRepository = saleRepository;
        _customerRepository = customerRepository;
    }
    
    public void AddSale(Sale sale)
    {
        if (sale.CustomerId <= 0)
        {
            throw new ArgumentException("El ID del cliente es obligatorio");
        }

        var customer = _customerRepository.GetById(sale.CustomerId);
        if (customer == null)
        {
            throw new ArgumentException("El cliente especificado no existe");
        }

        if (sale.Total <= 0)
        {
            throw new ArgumentException("El total debe ser mayor que 0");
        }
        _saleRepository.Create(sale);
    }

    public Sale GetSaleById(int id)
    {
        return _saleRepository.GetById(id);
    }
}