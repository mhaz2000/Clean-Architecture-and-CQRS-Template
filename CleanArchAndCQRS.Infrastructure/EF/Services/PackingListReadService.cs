using CleanArchAndCQRS.Application.Services;
using CleanArchAndCQRS.Infrastructure.EF.Contexts;
using CleanArchAndCQRS.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchAndCQRS.Infrastructure.EF.Services
{
    internal sealed class PackingListReadService : IPackingListReadService
    {
        private readonly DbSet<PackingListReadModel> _packingLists;

        public PackingListReadService(ReadDbContext context)
            => _packingLists = context.PackingLists;

        public Task<bool> ExistsByNameAsync(string name)
            => _packingLists.AnyAsync(pl => pl.Name == name);
    }
}
