using CleanArchAndCQRS.Shared.Abstractions.Commands;
using MediatR;

namespace CleanArchAndCQRS.Shared.Commands
{
    internal sealed class InMemoryCommandDispatcher : ICommandDispatcher
    {
        private readonly IMediator _mediator;

        public InMemoryCommandDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            await _mediator.Send(command);
        }
    }
}
