using CleanArchAndCQRS.Domain.Exceptions;

namespace CleanArchAndCQRS.Domain.ValueObjects
{
    public record TravelDays
    {
        public uint Value { get; }

        public TravelDays(uint value)
        {
            if (value is 0 or > 100)
                throw new InvalidTravelDaysException(value);

            Value = value;
        }

        public static implicit operator TravelDays(uint travelDays) =>
            new(travelDays);


        public static implicit operator uint(TravelDays travelDays) =>
            travelDays.Value;
    }
}
