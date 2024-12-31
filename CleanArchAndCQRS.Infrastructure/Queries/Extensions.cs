using CleanArchAndCQRS.Application.DTO;
using CleanArchAndCQRS.Infrastructure.Models;

namespace CleanArchAndCQRS.Infrastructure.Queries
{
    internal static class Extensions
    {
        public static PackingListDto AsDto(this PackingListReadModel packingList)
            => new PackingListDto()
            {
                Id = packingList.Id,
                Name = packingList.Name,
                Localization = new LocalizationDto()
                {
                    City = packingList.Localization.City,
                    Country = packingList.Localization.Country,
                },
                Items = packingList.Items.Select(s => new PackingItemDto()
                {
                    Name = s.Name,
                    IsPacked = s.IsPacked,
                    Quantity = s.Quantity,
                })
            };
    }
}
