using Impar.Backend.Evaluation.Messager.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Impar.Backend.Evaluation.Messager.Bootstrap
{
    public static class MessagerDependencyInjection
    {
        public static IServiceCollection ResolveMessagerDependenciesInjection(this IServiceCollection services)
        {
            services.AddScoped<IRabbitMQService, RabbitMQService>();

            return services;
        }
    }
}
