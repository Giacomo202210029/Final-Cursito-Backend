using ExamenFinalCursitoBackend.BookShop.DataAccess.Models;
using MySqlConnector;

namespace ExamenFinalCursitoBackend.BookShop.DataAccess.Repositories;

public class BookRepository : IBookRepository
{
    private readonly string _connectionString;

    public BookRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public void Create(Book book)
    {
        // Esto permite que se cree una conexión con la base de datos
        using (var connection = new MySqlConnection(_connectionString))
        {
            // Esto permite que se abra la conexión con la base de datos
            connection.Open();
            
            // Esto permite que se haga la inserción de los libros en la base de datos
            var query = "INSERT INTO Books (Title, Author, ISBN, Genre, Price, InventoryQuantity) VALUES (@Title, @Author, @ISBN, @Genre, @Price, @InventoryQuantity)";
            
            // Esto permite que se cree un comando para la base de datos
            using (var command = new MySqlCommand(query, connection))
            {
                // Esto permite que se hagan las inserciones de los libros en la base de datos
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@ISBN", book.Isbn);
                command.Parameters.AddWithValue("@Genre", book.Genre);
                command.Parameters.AddWithValue("@Price", book.Price);
                command.Parameters.AddWithValue("@InventoryQuantity", book.InventoryQuantity);
                
                // Esto permite que se ejecute el comando
                //Execute non query es para comandos que no devuelven nada
                //non query es para insert, update, delete
                command.ExecuteNonQuery();
            }
        }
    }

    public void Update(Book book)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            var query = "UPDATE Libros SET Title = @Title, Author = @Author, ISBN = @ISBN, Genre = @Genre, Price = @Price, InventoryQuantity = @InventoryQuantity WHERE Id = @Id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@ISBN", book.Isbn);
                command.Parameters.AddWithValue("@Genre", book.Genre);
                command.Parameters.AddWithValue("@Price", book.Price);
                command.Parameters.AddWithValue("@InventoryQuantity", book.InventoryQuantity);
                command.ExecuteNonQuery();
            }
        }
    }

    public void Delete(int id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            // Esto permite que se abra la conexión con la base de datos
            connection.Open();

            // Esto permite que se haga la inserción de los libros en la base de datos
            var query = "DELETE FROM Books WHERE Id = @Id";

            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        } 

    }

    public Book GetById(int id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            // Esto permite que se abra la conexión con la base de datos
            connection.Open();

            // Esto permite que se haga la inserción de los libros en la base de datos
            var query = "SELECT FROM Books WHERE Id = @Id";

            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Book
                        {
                            Id = reader.GetInt32("Id"),
                            Title = reader.GetString("Title"),
                            Author = reader.GetString("Author"),
                            Isbn = reader.GetString("Isbn"),
                            Genre = reader.GetString("Genre"),
                            Price = reader.GetDecimal("Price"),
                            InventoryQuantity = reader.GetInt32("InventoryQuantity")
                        };
                    }
                }

            }
        }
        return null; 
    }
}