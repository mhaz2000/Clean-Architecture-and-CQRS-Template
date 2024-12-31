using CleanArchAndCQRS.Shared.Abstractions.Commands;

namespace CleanArchAndCQRS.Application.Commands
{
    public record AddPackingItem(Guid PackingListId, string Name, uint Quantity) : ICommand;
}
