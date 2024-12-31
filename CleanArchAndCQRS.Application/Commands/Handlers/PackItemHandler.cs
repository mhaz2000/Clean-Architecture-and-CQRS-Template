using CleanArchAndCQRS.Application.Exceptions;
using CleanArchAndCQRS.Domain.Repositories;
using MediatR;

namespace CleanArchAndCQRS.Application.Commands.Handlers
{
    public class PackItemHandler : IRequestHandler<PackItem>
    {
        private readonly IPackingListRepository _repository;

        public PackItemHandler(IPackingListRepository repository)
            => _repository = repository;


        public async Task Handle(PackItem command, CancellationToken cancellationToken)
        {
            var packingList = await _repository.GetAsync(command.PackingListId);

            if (packingList is null)
                throw new PackingListNotFoundException();

            packingList.PackItem(command.Name);

            await _repository.UpdateAsync(packingList);
        }
    }
}
