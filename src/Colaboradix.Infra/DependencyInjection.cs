using System.Reflection;
using Colaboradix.Application.Common.Commands;
using Colaboradix.Application.Common.Interfaces;
using Colaboradix.Domain.Repositories;
using Colaboradix.Infra.Context;
using Colaboradix.Infra.Repositories;
using Colaboradix.Infra.Services;
using FluentValidation;
using MediatR;
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

            services.AddContext(connectionString);
            services.AddServices(connectionString);
            services.AddRepositories();

            return services;
        }

        private static IServiceCollection AddContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<ISqlQueryService, SqlQueryService>(s =>
            {
                return new SqlQueryService(connectionString);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITeamRepository, TeamRepository>();

            return services;
        }
    }
}
