using CleanArchAndCQRS.Application.Exceptions;
using CleanArchAndCQRS.Domain.Repositories;
using CleanArchAndCQRS.Domain.ValueObjects;
using CleanArchAndCQRS.Shared.Abstractions.Commands;
using MediatR;

namespace CleanArchAndCQRS.Application.Commands.Handlers
{
    public class AddPackingItemHandler : ICommandHandler<AddPackingItem>
    {
        private readonly IPackingListRepository _repository;

        public AddPackingItemHandler(IPackingListRepository repository)
            => _repository = repository;
        

        public async Task Handle(AddPackingItem command, CancellationToken cancellationToken)
        {
            var packingList = await _repository.GetAsync(command.PackingListId);

            if (packingList is null)
                throw new PackingListNotFoundException();

            var packingItem = new PackingItem(command.Name, command.Quantity);
            packingList.AddItem(packingItem);

            await _repository.UpdateAsync(packingList);
        }
    }
}
