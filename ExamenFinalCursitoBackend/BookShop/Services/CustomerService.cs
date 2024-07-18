using ExamenFinalCursitoBackend.BookShop.DataAccess.Models;
using ExamenFinalCursitoBackend.BookShop.DataAccess.Repositories;

namespace ExamenFinalCursitoBackend.BookShop.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    
    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public void AddCustomer(Customer customer)
    {
        _customerRepository.Create(customer);
    }

    public Customer GetCustomerById(int id)
    {
        return _customerRepository.GetById(id);
    }
}