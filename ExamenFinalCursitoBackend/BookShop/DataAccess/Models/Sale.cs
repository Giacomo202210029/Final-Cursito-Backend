namespace ExamenFinalCursitoBackend.BookShop.DataAccess.Models;

public class Sale
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Date { get; set; }
    public decimal Total { get; set; }
    
    public Sale(int id, int customerId, string date, decimal total)
    {
        Id = id;
        CustomerId = customerId;
        Date = date;
        Total = total;
    }
    
    public Sale()
    {
    }
}