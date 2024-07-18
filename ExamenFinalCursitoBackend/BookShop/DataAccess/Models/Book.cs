using System.ComponentModel.DataAnnotations;

namespace ExamenFinalCursitoBackend.BookShop.DataAccess.Models;

public class Book
{
    public int Id { get; set; }
    
    [MaxLength(100, ErrorMessage = "El titulo no puede tener más de 100 caracteres")] 
    public string? Title { get; set; }
    
    [MaxLength(100, ErrorMessage = "El autor no puede tener más de 100 caracteres")] 
    public string? Author { get; set; }
    
    [MaxLength(20, ErrorMessage = "El Isbn no puede tener más de 20 caracteres")] 
    public string? Isbn { get; set; }
    
    [MaxLength(20, ErrorMessage = "El genero no puede tener más de 20 caracteres")] 
    public string? Genre { get; set; }
    
    public decimal Price { get; set; }
    
    public int InventoryQuantity { get; set; }
    
    public Book(int id, string? title, string? author, string? isbn, string? genre, decimal price, int inventoryQuantity)
    {
        Id = id;
        Title = title;
        Author = author;
        Isbn = isbn;
        Genre = genre;
        Price = price;
        InventoryQuantity = inventoryQuantity;
    }
    
    public Book()
    {
    }
    
}