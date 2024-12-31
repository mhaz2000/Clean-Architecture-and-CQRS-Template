using CleanArchAndCQRS.Shared.Abstractions.Exceptions;

namespace CleanArchAndCQRS.Domain.Exceptions
{
    public class InvalidTravelDaysException : PackItException
    {
        public uint Days { get; }
        public InvalidTravelDaysException(uint days) : base($"Value {days} is invalid travel days.")
            => Days = days;
    }
}
