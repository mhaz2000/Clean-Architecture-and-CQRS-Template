using CleanArchAndCQRS.Domain.ValueObjects;

namespace CleanArchAndCQRS.Domain.Policies.Temperature
{
    internal class LowTemperaturePolicy : IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>()
            {
                new PackingItem("Winter Hat", 1),
                new PackingItem("Scarf", 1),
                new PackingItem("Gloves", 1),
                new PackingItem("Hodies", 1),
                new PackingItem("Warm Jacket", 1),
            };

        public bool IsApplicable(PolicyData data)
            => data.Temperature < 100;
    }
}
