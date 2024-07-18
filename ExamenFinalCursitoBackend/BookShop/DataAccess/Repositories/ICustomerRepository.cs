using ExamenFinalCursitoBackend.BookShop.DataAccess.Models;

namespace ExamenFinalCursitoBackend.BookShop.DataAccess.Repositories;

public interface ICustomerRepository
{
    public void Create(Customer customer);
    
    public Customer GetById(int id);
}