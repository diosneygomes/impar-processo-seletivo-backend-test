using Impar.BackEnd.Evaluation.Data.Context;
using Microsoft.EntityFrameworkCore;
using Impar.BackEnd.Evaluation.Application.Bootstrap;
using Impar.BackEnd.Evaluation.Data.Bootstrap;
using Impar.BackEnd.Evaluation.Service.Bootstrap;
using Impar.Backend.Evaluation.Messager.Bootstrap;
using Impar.Backend.Evaluation.Worker;
using Impar.Backend.Evaluation.Messager.Configurations;

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


        // Obtém as configurações do rabbitMQ
        var rabbitMqSetting = builder.Configuration
            .GetSection(nameof(RabbitMQSetting));

        builder.Services
            .Configure<RabbitMQSetting>(rabbitMqSetting);

        builder.Services.ResolveDataDependenciesInjection();
        builder.Services.ResolveServiceDependenciesInjection();
        builder.Services.ResolveApplicationDependenciesInjection();
        builder.Services.ResolveMessagerDependenciesInjection();

        // habilita worker para funcionar simultaneamente com a API
        //builder.Services.AddHostedService<Worker>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}