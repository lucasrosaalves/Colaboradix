using Colaboradix.Domain.Common;
using Colaboradix.Domain.Repositories;
using Colaboradix.Infra.Data.Domain.Common;
using Colaboradix.Infra.Data.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Colaboradix.Infra.Data
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

            services.AddScoped<ISqlQueryService, SqlQueryService>(s =>
            {
                return new SqlQueryService(connectionString);
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
