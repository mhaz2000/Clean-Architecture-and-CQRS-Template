using CleanArchAndCQRS.Application.DTO.External;
using CleanArchAndCQRS.Application.Services;
using CleanArchAndCQRS.Domain.ValueObjects;

namespace CleanArchAndCQRS.Infrastructure.Services
{
    internal sealed class DumbWeatherService : IWeatherService
    {
        public Task<WeatherDto> GetWeatherAsync(Localization localization)
            => Task.FromResult(new WeatherDto(new Random().Next(5, 30)));
    }
}
