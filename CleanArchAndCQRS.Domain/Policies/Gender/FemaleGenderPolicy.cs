using CleanArchAndCQRS.Domain.ValueObjects;

namespace CleanArchAndCQRS.Domain.Policies.Gender
{
    internal class FemaleGenderPolicy : IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>()
            {
                new PackingItem("Lipstick", 1),
                new PackingItem("Powder", 1),
                new PackingItem("Eyeliner", 2),
            };

        public bool IsApplicable(PolicyData data)
            => data.Gender is Consts.Gender.Female;
    }
}
