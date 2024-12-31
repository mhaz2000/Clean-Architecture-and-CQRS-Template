using CleanArchAndCQRS.Domain.ValueObjects;

namespace CleanArchAndCQRS.Domain.Policies.Gender
{
    internal class MaleGenderPolicy : IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>()
            {
                new PackingItem("laptop", 1),
                new PackingItem("Beer", 10),
                new PackingItem("Book", 5),
            };

        public bool IsApplicable(PolicyData data)
            => data.Gender is Consts.Gender.Male;
    }
}
