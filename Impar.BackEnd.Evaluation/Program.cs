using Impar.BackEnd.Evaluation;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddDbContext<MessagesDbContext>(options => options.UseSqlServer("Server=localhost;Database=impar-evaluation-db;User=sa;Password=123@mudar;TrustServerCertificate=True"));

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}