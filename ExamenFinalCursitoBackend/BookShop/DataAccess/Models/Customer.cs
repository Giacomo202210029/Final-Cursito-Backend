using System.ComponentModel.DataAnnotations;

namespace ExamenFinalCursitoBackend.BookShop.DataAccess.Models;

public class Customer
{
    public int Id { get; set; }
    
    [MaxLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
    public string Name { get; set; }
    
    [MaxLength(100, ErrorMessage = "El apellido no puede tener más de 100 caracteres")]
    public string LastName { get; set; }
    public string Email { get; set; }
    
    [MaxLength(20, ErrorMessage = "El número de teléfono no puede tener más de 20 caracteres")]
    public string  PhoneNumber { get; set; }
    
    [MaxLength(255, ErrorMessage = "La dirección no puede tener más de 255 caracteres")]
    public string Address { get; set; }
    
    public Customer(int id, string name, string lastName, string email, string phone, string address)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Email = email;
        PhoneNumber = phone;
        Address = address;
    }

    public Customer()
    {
        
    }
}