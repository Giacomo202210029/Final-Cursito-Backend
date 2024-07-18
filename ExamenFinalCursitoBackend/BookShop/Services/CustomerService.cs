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
        if (string.IsNullOrEmpty(customer.Name))
        {
            throw new ArgumentException("El nombre es obligatorio");
        }

        if (string.IsNullOrEmpty(customer.LastName))
        {
            throw new ArgumentException("El apellido es obligatorio");
        }

        if (string.IsNullOrEmpty(customer.Email))
        {
            throw new ArgumentException("El correo electrónico es obligatorio");
        }

        if (!IsValidEmail(customer.Email))
        {
            throw new ArgumentException("El formato del correo electrónico no es válido");
        }

        if (string.IsNullOrEmpty(customer.PhoneNumber))
        {
            throw new ArgumentException("El número de teléfono es obligatorio");
        }

        if (string.IsNullOrEmpty(customer.Address))
        {
            throw new ArgumentException("La dirección es obligatoria");
        }

        _customerRepository.Create(customer);
    }

    public Customer? GetCustomerById(int id)
    {
        return _customerRepository.GetById(id);
    }
    
    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}