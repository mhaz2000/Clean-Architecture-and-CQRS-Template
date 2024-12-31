using MediatR;

namespace CleanArchAndCQRS.Shared.Abstractions.Queries
{
    public interface IQuery : IRequest;

    public interface IQuery<TResult> : IQuery, IRequest<TResult>;
}
