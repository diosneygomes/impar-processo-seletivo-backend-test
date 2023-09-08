using Impar.BackEnd.Evaluation.Core.Interfaces.Repositories;
using Impar.BackEnd.Evaluation.Data.Context;
using Impar.BackEnd.Evaluation.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Impar.BackEnd.Evaluation.Data.Bootstrap
{
    public static class DataDependencyInjection
    {
        public static IServiceCollection ResolveDataDependenciesInjection(this IServiceCollection services)
        {
            services.AddScoped<MessagesDbContext>();

            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
