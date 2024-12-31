using CleanArchAndCQRS.Domain.Entities;
using CleanArchAndCQRS.Domain.Repositories;
using CleanArchAndCQRS.Domain.ValueObjects;
using CleanArchAndCQRS.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchAndCQRS.Infrastructure.EF.Repositories
{
    internal sealed class PackingListRepository : IPackingListRepository
    {
        private readonly DbSet<PackingList> _packingList;
        private readonly WriteDbContext _writeDbContext;


        public PackingListRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _packingList = writeDbContext.PackingLists;
        }

        public async Task AddAsync(PackingList packingList)
        {
            await _packingList.AddAsync(packingList);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(PackingList packingList)
        {
            _packingList.Remove(packingList);
            await _writeDbContext.SaveChangesAsync();
        }

        public Task<PackingList> GetAsync(PackingListId id)
            => _packingList.Include("_items").SingleOrDefaultAsync(pl => pl.Id == id)!;

        public async Task UpdateAsync(PackingList packingList)
        {
            _packingList.Update(packingList);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
