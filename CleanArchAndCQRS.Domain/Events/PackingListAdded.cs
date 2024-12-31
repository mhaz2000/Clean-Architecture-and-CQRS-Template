using CleanArchAndCQRS.Domain.Entities;
using CleanArchAndCQRS.Domain.ValueObjects;
using CleanArchAndCQRS.Shared.Abstractions.Domain;

namespace CleanArchAndCQRS.Domain.Events
{
    public record PackingListAdded(PackingList PackingList, PackingItem PackingItem) : IDomainEvent;


}
