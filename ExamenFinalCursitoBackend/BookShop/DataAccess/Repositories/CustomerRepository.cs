using ExamenFinalCursitoBackend.BookShop.DataAccess.Models;
using MySqlConnector;

namespace ExamenFinalCursitoBackend.BookShop.DataAccess.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly string _connectionString;

    public CustomerRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public void Create(Customer customer)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            // Esto permite que se abra la conexión con la base de datos
            connection.Open();
            
            var query = "INSERT INTO Customers (Name, LastName, Email, Address, PhoneNumber) VALUES (@Name, @LastName, @Email, @Address, @PhoneNumber)";
            
            // Esto permite que se cree un comando para la base de datos
            using (var command = new MySqlCommand(query, connection))
            {
                // Esto permite que se hagan las inserciones de los libros en la base de datos
                command.Parameters.AddWithValue("@Name", customer.Name);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@Address", customer.Address);
                command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                
                // Esto permite que se ejecute el comando
                //Execute non query es para comandos que no devuelven nada
                //non query es para insert, update, delete
                command.ExecuteNonQuery();
            }
        }
    }

    public Customer? GetById(int id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            // Esto permite que se abra la conexión con la base de datos
            connection.Open();

            // Esto permite que se haga la inserción de los libros en la base de datos
            var query = "SELECT * FROM Customers WHERE Id = @Id";

            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Customer
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader.GetString("Name"),
                            LastName = reader.GetString("LastName"),
                            Email = reader.GetString("Email"),
                            PhoneNumber = reader.GetString("PhoneNumber"),
                            Address = reader.GetString("Address"),
                        };
                    }
                }

            }
        }
        return null; 
    }
}