using Impar.Backend.Evaluation.Worker;
using Impar.BackEnd.Evaluation.Application.Interfaces;
using Impar.BackEnd.Evaluation.Application.ApplicationServices;
using Impar.BackEnd.Evaluation.Core.Interfaces.Services;
using Impar.BackEnd.Evaluation.Service.Servicies;
using Impar.BackEnd.Evaluation.Core.Interfaces.Repositories;
using Impar.BackEnd.Evaluation.Data.Repositories;
using Impar.Backend.Evaluation.Messager.Interfaces;
using Impar.Backend.Evaluation.Messager;
using Impar.BackEnd.Evaluation.Data.Context;
using Microsoft.EntityFrameworkCore;
using Impar.BackEnd.Evaluation.Application.Bootstrap;
using Impar.BackEnd.Evaluation.Data.Bootstrap;
using Impar.BackEnd.Evaluation.Service.Bootstrap;
using Impar.Backend.Evaluation.Messager.Bootstrap;

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
