using CleanArchAndCQRS.Domain.ValueObjects;
using CleanArchAndCQRS.Shared.Abstractions.Exceptions;

namespace CleanArchAndCQRS.Application.Exceptions
{
    public class MissingLocalizationWeatherException : PackItException
    {
        public Localization Localization { get; set; }
        public MissingLocalizationWeatherException(Localization localization) :
            base($"Couldn't fetch weather data for localization '{localization.country}/{localization.city}'.")
        {
            Localization = localization;
        }
    }
}
