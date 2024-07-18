using ExamenFinalCursitoBackend.BookShop.DataAccess.Repositories;
using ExamenFinalCursitoBackend.BookShop.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddTransient<IBookRepository>(provider => new BookRepository(connectionString));
builder.Services.AddTransient<ICustomerRepository>(provider => new CustomerRepository(connectionString));
builder.Services.AddTransient<ISaleRepository>(provider => new SaleRepository(connectionString));

builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<ISaleService, SaleService>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();