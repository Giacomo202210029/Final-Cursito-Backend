using ExamenFinalCursitoBackend.BookShop.DataAccess.Models;
using MySqlConnector;

namespace ExamenFinalCursitoBackend.BookShop.DataAccess.Repositories;

public class SaleRepository : ISaleRepository
{

    private readonly string _connectionString;

    public SaleRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Create(Sale sale)
    {
        // Esto permite que se cree una conexión con la base de datos
        using (var connection = new MySqlConnection(_connectionString))
        {
            // Esto permite que se abra la conexión con la base de datos
            connection.Open();

            // Esto permite que se haga la inserción de los libros en la base de datos
            var query = "INSERT INTO Sales (CustomerId, Date, Total) VALUES (@CustomerId, @Date, @Total)";

            // Esto permite que se cree un comando para la base de datos
            using (var command = new MySqlCommand(query, connection))
            {
                // Esto permite que se hagan las inserciones de los libros en la base de datos
                command.Parameters.AddWithValue("@Title", sale.CustomerId);
                command.Parameters.AddWithValue("@Author", sale.Date);
                command.Parameters.AddWithValue("@ISBN", sale.Total);

                // Esto permite que se ejecute el comando
                //Execute non query es para comandos que no devuelven nada
                //non query es para insert, update, delete
                command.ExecuteNonQuery();
            }
        }
    }

    public Sale GetById(int id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            // Esto permite que se abra la conexión con la base de datos
            connection.Open();

            // Esto permite que se haga la inserción de los libros en la base de datos
            var query = "SELECT FROM Sales WHERE Id = @Id";

            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Sale
                        {
                            Id = reader.GetInt32("Id"),
                            CustomerId = reader.GetInt32("CustomerId"),
                            Date = reader.GetString("Date"),
                            Total = reader.GetDecimal("Total")
                        };
                    }
                }

            }
        }

        return null; 
    }
} 