using CleanArchAndCQRS.Application;
using CleanArchAndCQRS.Application.Services;
using CleanArchAndCQRS.Infrastructure.EF;
using CleanArchAndCQRS.Infrastructure.Logging;
using CleanArchAndCQRS.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchAndCQRS.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSql(configuration);
            services.AddApplication();


            services.AddSingleton<LoggingMiddleware>();

            Console.WriteLine("Decorator has been registered.");

            services.AddSingleton<IWeatherService, DumbWeatherService>();

            return services;
        }

    }
}
