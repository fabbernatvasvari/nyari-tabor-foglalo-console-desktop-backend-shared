using MyApp.Backend.Context;
using MyApp.Backend.Extensions;
using MyApp.Shared.Models;
using Org.BouncyCastle.Asn1.Ocsp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddBackend();

var app = builder.Build();

// InMemory database data
using (var scope = app.Services.CreateAsyncScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppInMemoryContext>();

    // InMemory test data
    dbContext.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Cors
app.UseCors("KretaCors");

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program {
        static void Main(string[] args)
        {
            Child child = new Child("Gipsz Jákob", new DateOnly(2017, 5, 15));
            Console.WriteLine(child);
        }
}
