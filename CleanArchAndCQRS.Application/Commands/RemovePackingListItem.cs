using CleanArchAndCQRS.Shared.Abstractions.Commands;

namespace CleanArchAndCQRS.Application.Commands
{
    public record RemovePackingItem(Guid PackingListId,  string Name) : ICommand;
}
