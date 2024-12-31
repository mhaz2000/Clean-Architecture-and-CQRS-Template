using CleanArchAndCQRS.Domain.Factories;
using CleanArchAndCQRS.Domain.Policies;
using CleanArchAndCQRS.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchAndCQRS.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddSingleton<IPackingListFactory, PackingListFactory>();

            services.Scan(b => b.FromAssemblies(typeof(IPackingItemsPolicy).Assembly)
                .AddClasses(c=> c.AssignableTo<IPackingItemsPolicy>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime());

            services.AddShared();
            return services;
        }
    }
}
