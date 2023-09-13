using Impar.BackEnd.Evaluation.Application.Bootstrap;
using Impar.BackEnd.Evaluation.Data.Bootstrap;
using Impar.BackEnd.Evaluation.Data.Context;
using Impar.Backend.Evaluation.Messager.Bootstrap;
using Impar.BackEnd.Evaluation.Service.Bootstrap;
using Impar.Backend.Evaluation.Worker;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services)=>
    {
        services
        .AddHostedService<Worker>();

        services.AddDbContext<MessagesDbContext>(options =>
        {
            options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection"));
        });

        services.ResolveDataDependenciesInjection();
        services.ResolveServiceDependenciesInjection();
        services.ResolveApplicationDependenciesInjection();
        services.ResolveMessagerDependenciesInjection();
    })
    .Build();

await host.RunAsync();
