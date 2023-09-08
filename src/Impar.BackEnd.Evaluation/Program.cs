using Impar.BackEnd.Evaluation.Data.Context;
using Microsoft.EntityFrameworkCore;
using Impar.BackEnd.Evaluation.Application.Bootstrap;
using Impar.BackEnd.Evaluation.Data.Bootstrap;
using Impar.BackEnd.Evaluation.Service.Bootstrap;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddDbContext<MessagesDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.ResolveDataDependenciesInjection();
        builder.Services.ResolveServiceDependenciesInjection();
        builder.Services.ResolveApplicationDependenciesInjection();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}