using CleanArchAndCQRS.Domain.Consts;
using CleanArchAndCQRS.Domain.Entities;
using CleanArchAndCQRS.Domain.Policies;
using CleanArchAndCQRS.Domain.ValueObjects;

namespace CleanArchAndCQRS.Domain.Factories
{
    public sealed class PackingListFactory : IPackingListFactory
    {
        private readonly IEnumerable<IPackingItemsPolicy> _policies;

        public PackingListFactory(IEnumerable<IPackingItemsPolicy> policies)
            => _policies = policies;
        public PackingList Create(PackingListId id, PackingListName name, Localization localization)
            => new PackingList(id, name, localization);

        public PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, TravelDays travelDays, Gender gender,
            Temperature temperature, Localization localization)
        {
            var data = new PolicyData(travelDays, gender, temperature, localization);
            var applicablePolicies = _policies.Where(c=> c.IsApplicable(data));

            var items = applicablePolicies.SelectMany(p => p.GenerateItems(data));
            var packingList = Create(id, name, localization);

            packingList.AddItems(items);

            return packingList;
        }
    }
}
