using CleanArchAndCQRS.Shared.Abstractions.Commands;

namespace CleanArchAndCQRS.Application.Commands
{
    public record PackItem(Guid PackingListId, string Name): ICommand;
}
