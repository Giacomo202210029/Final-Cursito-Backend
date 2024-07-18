namespace ExamenFinalCursitoBackend.BookShop.DataAccess.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }
    public int InventoryQuantity { get; set; }
    
    public Book(int id, string title, string author, string isbn, string genre, decimal price, int inventoryQuantity)
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