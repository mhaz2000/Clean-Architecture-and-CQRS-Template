using CleanArchAndCQRS.Shared.Abstractions.Queries;
using MediatR;

namespace CleanArchAndCQRS.Shared.Queries
{
    internal sealed class InMemoryQueryDispatcher : IQueryDispatcher
    {
        private readonly IMediator _mediator;

        public InMemoryQueryDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

           return await _mediator.Send<TResult>(query);
        }
    }
}
