using CleanArchAndCQRS.Application.Exceptions;
using CleanArchAndCQRS.Domain.Repositories;
using CleanArchAndCQRS.Shared.Abstractions.Commands;
using MediatR;

namespace CleanArchAndCQRS.Application.Commands.Handlers
{
    public class RemovePackingItemHandler : ICommandHandler<RemovePackingItem>
    {
        private readonly IPackingListRepository _repository;

        public RemovePackingItemHandler(IPackingListRepository repository)
            => _repository = repository;


        public async Task Handle(RemovePackingItem command, CancellationToken cancellationToken)
        {
            var packingList = await _repository.GetAsync(command.PackingListId);

            if (packingList is null)
                throw new PackingListNotFoundException();

            packingList.RemoveItem(command.Name);

            await _repository.UpdateAsync(packingList);
        }
    }
}
