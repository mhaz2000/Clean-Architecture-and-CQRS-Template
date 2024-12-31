using CleanArchAndCQRS.Domain.ValueObjects;

namespace CleanArchAndCQRS.Domain.Policies
{
    public interface IPackingItemsPolicy
    {
        bool IsApplicable(PolicyData data);
        IEnumerable<PackingItem> GenerateItems(PolicyData data);
    }
}
