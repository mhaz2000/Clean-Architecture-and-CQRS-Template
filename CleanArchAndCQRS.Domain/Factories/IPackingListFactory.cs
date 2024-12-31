using CleanArchAndCQRS.Domain.Consts;
using CleanArchAndCQRS.Domain.Entities;
using CleanArchAndCQRS.Domain.ValueObjects;

namespace CleanArchAndCQRS.Domain.Factories
{
    public interface IPackingListFactory
    {
        PackingList Create(PackingListId id, PackingListName name, Localization localization);
        PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, TravelDays travelDays, Gender gender,
            Temperature temperature, Localization localization);
    } 
}
