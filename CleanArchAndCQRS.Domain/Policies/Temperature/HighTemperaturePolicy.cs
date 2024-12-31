using CleanArchAndCQRS.Domain.ValueObjects;

namespace CleanArchAndCQRS.Domain.Policies.Temperature
{
    internal class HighTemperaturePolicy : IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>()
            {
                new PackingItem("Hat", 1),
                new PackingItem("Sunglasses", 1),
                new PackingItem("Cream with UV filter", 1),
            };

        public bool IsApplicable(PolicyData data)
            => data.Temperature > 250;
    }
}
