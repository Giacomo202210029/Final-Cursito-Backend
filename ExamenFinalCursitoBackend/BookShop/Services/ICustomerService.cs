using ExamenFinalCursitoBackend.BookShop.DataAccess.Models;

namespace ExamenFinalCursitoBackend.BookShop.Services;

public interface ICustomerService
{
    public void AddCustomer(Customer customer);
    
    public Customer GetCustomerById(int id);
}