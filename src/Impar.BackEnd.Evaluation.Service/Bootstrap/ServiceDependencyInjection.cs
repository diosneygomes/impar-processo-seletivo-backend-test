using Impar.BackEnd.Evaluation.Core.Interfaces.Services;
using Impar.BackEnd.Evaluation.Service.Servicies;
using Microsoft.Extensions.DependencyInjection;

namespace Impar.BackEnd.Evaluation.Service.Bootstrap
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection ResolveServiceDependenciesInjection(this IServiceCollection services)
        {
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
