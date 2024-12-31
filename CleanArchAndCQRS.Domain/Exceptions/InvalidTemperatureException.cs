using CleanArchAndCQRS.Shared.Abstractions.Exceptions;

namespace CleanArchAndCQRS.Domain.Exceptions
{
    public class InvalidTemperatureException : PackItException
    {
        public double Temperature { get; }
        public InvalidTemperatureException(double temperature) : base($"Value {temperature} is invalid travel days.")
            => Temperature = temperature;
    }
}
