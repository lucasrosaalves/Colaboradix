using Colaboradix.Domain.Common;
using Colaboradix.Domain.Repositories;
using Colaboradix.Infra.Data.Context;
using Colaboradix.Infra.Data.Factories;
using Colaboradix.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Colaboradix.Infra.Data.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("ColaboradixDb");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>(s =>
            {
                return new SqlConnectionFactory(connectionString);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITeamRepository, TeamRepository>();

            return services;
        }
    }
}
