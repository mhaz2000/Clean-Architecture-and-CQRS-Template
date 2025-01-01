using CleanArchAndCQRS.Application.Exceptions;
using CleanArchAndCQRS.Domain.Repositories;
using CleanArchAndCQRS.Shared.Abstractions.Commands;
using MediatR;

namespace CleanArchAndCQRS.Application.Commands.Handlers
{
    public class DeletePackingListHandler : ICommandHandler<DeletePackingList>
    {
        private readonly IPackingListRepository _repository;

        public DeletePackingListHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeletePackingList command, CancellationToken cancellationToken)
        {
            var packingList = await _repository.GetAsync(command.Id);

            if (packingList is null)
                throw new PackingListNotFoundException();

            await _repository.DeleteAsync(packingList);
        }
    }
}
