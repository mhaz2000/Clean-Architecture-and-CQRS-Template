using CleanArchAndCQRS.Application.DTO.External;
using CleanArchAndCQRS.Domain.ValueObjects;

namespace CleanArchAndCQRS.Application.Services
{
    public interface IWeatherService
    {
        Task<WeatherDto> GetWeatherAsync(Localization localization);
    }
}
