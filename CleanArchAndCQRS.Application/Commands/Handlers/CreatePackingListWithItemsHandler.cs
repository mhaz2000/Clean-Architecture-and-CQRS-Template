using CleanArchAndCQRS.Application.Exceptions;
using CleanArchAndCQRS.Application.Services;
using CleanArchAndCQRS.Domain.Factories;
using CleanArchAndCQRS.Domain.Repositories;
using CleanArchAndCQRS.Domain.ValueObjects;
using CleanArchAndCQRS.Shared.Abstractions.Commands;
using MediatR;

namespace CleanArchAndCQRS.Application.Commands.Handlers
{
    public class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
    {
        private readonly IPackingListReadService _readService;
        private readonly IPackingListFactory _factory;
        private readonly IPackingListRepository _repository;
        private readonly IWeatherService _weatherService;

        public CreatePackingListWithItemsHandler(IPackingListRepository repository, IPackingListReadService readService,
            IPackingListFactory factory, IWeatherService weatherService)
        {
            _repository = repository;
            _readService = readService;
            _factory = factory;
            _weatherService = weatherService;
        }

        public async Task Handle(CreatePackingListWithItems command, CancellationToken cancellationToken)
        {
            var (id, name, days, gender, localizationWriteModel) = command;

            if (await _readService.ExistsByNameAsync(command.Name))
                throw new PackingListAlreadyExistsException(name);

            var localization = new Localization(localizationWriteModel.city, localizationWriteModel.country);
            var weather = await _weatherService.GetWeatherAsync(localization);

            if (weather is null)
                throw new MissingLocalizationWeatherException(localization);

            var packingList = _factory.CreateWithDefaultItems(id, name, days, gender, weather.Temperature, localization);

            await _repository.AddAsync(packingList);
        }
    }
}
