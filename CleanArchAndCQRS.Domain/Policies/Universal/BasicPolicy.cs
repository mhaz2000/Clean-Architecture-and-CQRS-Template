using CleanArchAndCQRS.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchAndCQRS.Domain.Policies.Universal
{
    internal sealed class BasicPolicy : IPackingItemsPolicy
    {
        private const uint MaximumQuantityOfClothes = 7;
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>()
            {
                new("Pants", Math.Min(data.Days, MaximumQuantityOfClothes)),
                new("Socks", Math.Min(data.Days, MaximumQuantityOfClothes)),
                new("T-Shirt", Math.Min(data.Days, MaximumQuantityOfClothes)),
                new("Shampoo", Math.Min(data.Days, 1)),
                new("Passport", Math.Min(data.Days, 1)),
                new("Towel", Math.Min(data.Days, 2)),
            }; 

        public bool IsApplicable(PolicyData _)
            => true;
    }
}
