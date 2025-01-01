using CleanArchAndCQRS.Shared.Abstractions.Commands;
using CleanArchAndCQRS.Shared.Abstractions.Queries;
using CleanArchAndCQRS.Shared.Commands;
using CleanArchAndCQRS.Shared.Exceptions;
using CleanArchAndCQRS.Shared.Queries;
using CleanArchAndCQRS.Shared.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchAndCQRS.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            services.AddHostedService<AppInitializer>();

            // Register MediatR
            var applicationAssembly = Assembly.Load("CleanArchAndCQRS.Application"); // Replace with your actual assembly name
            var infrastructureAssembly = Assembly.Load("CleanArchAndCQRS.Infrastructure"); // Replace with your actual assembly name

            // Register MediatR and include the dynamically loaded assembly
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); // Shared project
                cfg.RegisterServicesFromAssembly(applicationAssembly); // Application project (loaded dynamically)
                cfg.RegisterServicesFromAssembly(infrastructureAssembly); // Infrastructure project (loaded dynamically)
            });

            // Register all ICommandHandler<> implementations after MediatR
            services.Scan(scan => scan
                .FromAssemblies(applicationAssembly, infrastructureAssembly)
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());


            // Register command and query dispatchers
            services.AddScoped<ICommandDispatcher, InMemoryCommandDispatcher>();
            services.AddScoped<IQueryDispatcher, InMemoryQueryDispatcher>();

            // Add middleware
            services.AddScoped<ExceptionMiddleware>();

            return services;
        }

        public static IApplicationBuilder UseShared(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }

    }
}
