using CleanArchAndCQRS.Application.Commands;
using CleanArchAndCQRS.Application.Commands.Handlers;
using CleanArchAndCQRS.Application.DTO.External;
using CleanArchAndCQRS.Application.Exceptions;
using CleanArchAndCQRS.Application.Services;
using CleanArchAndCQRS.Domain.Consts;
using CleanArchAndCQRS.Domain.Entities;
using CleanArchAndCQRS.Domain.Factories;
using CleanArchAndCQRS.Domain.Repositories;
using CleanArchAndCQRS.Domain.ValueObjects;
using CleanArchAndCQRS.Shared.Abstractions.Commands;
using FakeItEasy;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchAndCQRS.UnitTests.Applications
{
    public class CreatePackingListWithItemsHandlerTests
    {
        #region ARRANGE

        private readonly ICommandHandler<CreatePackingListWithItems> _commandHandler;
        private readonly IPackingListRepository _repository;
        private readonly IWeatherService _weatherService;
        private readonly IPackingListReadService _readService;
        private readonly IPackingListFactory _factory;

        public CreatePackingListWithItemsHandlerTests()
        {
            _repository = A.Fake<IPackingListRepository>();
            _weatherService = A.Fake<IWeatherService>();
            _readService = A.Fake<IPackingListReadService>();
            _factory = A.Fake<IPackingListFactory>();

            _commandHandler = new CreatePackingListWithItemsHandler(_repository, _readService, _factory, _weatherService);
        }

        #endregion

        Task Act(CreatePackingListWithItems command)
            => _commandHandler.Handle(command, CancellationToken.None);

        [Fact]
        public async Task HandleAsync_Throws_PackingListAlreadyExistsException_When_List_With_same_Name_Already_Exists()
        {
            var command = new CreatePackingListWithItems(Guid.NewGuid(), "MyList", 10, Gender.Female, default);

            A.CallTo(() => _readService.ExistsByNameAsync(command.Name)).Returns(true);

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PackingListAlreadyExistsException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_MissingLocalizationWeatherException_When_Weather_Is_Not_Returned_From_Service()
        {
            WeatherDto mockWeatherDto = null;

            var command = new CreatePackingListWithItems(Guid.NewGuid(), "MyList", 10, Gender.Female,
                new LocalizationWriteModel("Warsaw", "Poland"));

            A.CallTo(() => _readService.ExistsByNameAsync(command.Name)).Returns(false);
            A.CallTo(() => _weatherService.GetWeatherAsync(A<Localization>._)).Returns(mockWeatherDto);

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingLocalizationWeatherException>();
        }

        [Fact]
        public async Task HandleAsync_Calls_Repository_On_Success()
        {
            var mockWeatherDto = new WeatherDto(1);
            var mockPakingList = new PackingList();

            var command = new CreatePackingListWithItems(Guid.NewGuid(), "MyList", 10, Gender.Female,
                new LocalizationWriteModel("Warsaw", "Poland"));

            A.CallTo(() => _readService.ExistsByNameAsync(command.Name)).Returns(false);
            A.CallTo(() => _weatherService.GetWeatherAsync(A<Localization>._)).Returns(mockWeatherDto);
            A.CallTo(() => _factory.CreateWithDefaultItems(command.Id, command.Name, command.Days, command.Gender, A<Temperature>._, A<Localization>._))
                .Returns(mockPakingList);

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldBeNull();
            A.CallTo(() => _repository.AddAsync(A<PackingList>._)).MustHaveHappenedOnceExactly();

        }

    }
}
