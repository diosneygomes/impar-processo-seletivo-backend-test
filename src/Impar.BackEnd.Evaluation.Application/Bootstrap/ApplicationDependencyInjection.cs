using Impar.BackEnd.Evaluation.Application.ApplicationServices;
using Impar.BackEnd.Evaluation.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Impar.BackEnd.Evaluation.Application.Bootstrap
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection ResolveApplicationDependenciesInjection(this IServiceCollection services)
        {
            services.AddScoped<IMessageApplication, MessageApplication>();

            return services;
        }
    }
}
