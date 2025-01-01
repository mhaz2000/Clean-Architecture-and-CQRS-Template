using MediatR;

namespace CleanArchAndCQRS.Shared.Abstractions.Commands
{

    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : class, ICommand;
}
