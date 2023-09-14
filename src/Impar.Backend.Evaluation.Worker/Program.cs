using Impar.BackEnd.Evaluation.Application.Bootstrap;
using Impar.BackEnd.Evaluation.Data.Bootstrap;
using Impar.BackEnd.Evaluation.Data.Context;
using Impar.Backend.Evaluation.Messager.Bootstrap;
using Impar.BackEnd.Evaluation.Service.Bootstrap;
using Impar.Backend.Evaluation.Worker;
using Microsoft.EntityFrameworkCore;
using Impar.Backend.Evaluation.Messager.Configurations;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services)=>
    {
        services
        .AddHostedService<Worker>();

        services.AddDbContext<MessagesDbContext>(options =>
        {
            options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection"));
        });

        // Obtém as configurações do rabbitMQ
        var rabbitMqSetting = hostContext.Configuration
            .GetSection(nameof(RabbitMQSetting));

        services
            .Configure<RabbitMQSetting>(rabbitMqSetting);

        services.ResolveDataDependenciesInjection();
        services.ResolveServiceDependenciesInjection();
        services.ResolveApplicationDependenciesInjection();
        services.ResolveMessagerDependenciesInjection();
    })
    .Build();

await host.RunAsync();
