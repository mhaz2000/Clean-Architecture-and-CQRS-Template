using CleanArchAndCQRS.Domain.Entities;
using CleanArchAndCQRS.Domain.ValueObjects;

namespace CleanArchAndCQRS.Domain.Repositories
{
    public interface IPackingListRepository
    {
        Task<PackingList> GetAsync(PackingListId id);
        Task AddAsync(PackingList packingList);
        Task UpdateAsync(PackingList packingList);
        Task DeleteAsync(PackingList packingList);
    }
}
