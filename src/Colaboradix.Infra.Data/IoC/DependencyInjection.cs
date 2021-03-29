using Colaboradix.Domain.Common;
using Colaboradix.Domain.Repositories;
using Colaboradix.Infra.Data.Context;
using Colaboradix.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Colaboradix.Infra.Data.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddContext();

            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

        private static IServiceCollection AddContext(this IServiceCollection services)
        {
            services.AddScoped<DbSession>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
