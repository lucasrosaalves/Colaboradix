using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace Colaboradix.Application.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
