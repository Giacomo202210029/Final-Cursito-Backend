namespace ExamenFinalCursitoBackend.BookShop.DataAccess.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    
    public string  PhoneNumber { get; set; }
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