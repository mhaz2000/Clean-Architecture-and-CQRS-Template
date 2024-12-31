using CleanArchAndCQRS.Shared.Abstractions.Commands;
using CleanArchAndCQRS.Shared.Abstractions.Queries;
using CleanArchAndCQRS.Shared.Commands;
using CleanArchAndCQRS.Shared.Queries;
using CleanArchAndCQRS.Shared.Services;
using MediatR;
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

            // Register MediatR and include the dynamically loaded assembly
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); // Shared project
                cfg.RegisterServicesFromAssembly(applicationAssembly); // Application project (loaded dynamically)
            });

            //services.AddScoped(typeof(IRequestHandler<,>), typeof(CreatePackingListWithItemsHandler));


            // Register ICommandDispatcher
            services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();
            services.AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>();

            return services;
        }


    }
}
