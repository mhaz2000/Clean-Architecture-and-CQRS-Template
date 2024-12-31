using CleanArchAndCQRS.Shared.Abstractions.Commands;

namespace CleanArchAndCQRS.Application.Commands
{
    public record DeletePackingList(Guid Id) : ICommand;
}
