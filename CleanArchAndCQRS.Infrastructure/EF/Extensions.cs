using CleanArchAndCQRS.Application.Services;
using CleanArchAndCQRS.Domain.Repositories;
using CleanArchAndCQRS.Infrastructure.EF.Contexts;
using CleanArchAndCQRS.Infrastructure.EF.Options;
using CleanArchAndCQRS.Infrastructure.EF.Repositories;
using CleanArchAndCQRS.Infrastructure.EF.Services;
using CleanArchAndCQRS.Shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchAndCQRS.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddSql(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetOptions<SqlOptions>("Sql");

            services.AddDbContext<ReadDbContext>(ctx => ctx.UseSqlServer(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(ctx => ctx.UseSqlServer(options.ConnectionString));

            services.AddScoped<IPackingListRepository, PackingListRepository>();
            services.AddScoped<IPackingListReadService, PackingListReadService>();


            return services;
        }
    }
}
