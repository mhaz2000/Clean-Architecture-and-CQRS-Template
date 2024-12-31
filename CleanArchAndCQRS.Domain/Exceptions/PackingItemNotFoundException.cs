using CleanArchAndCQRS.Shared.Abstractions.Exceptions;

namespace CleanArchAndCQRS.Domain.Exceptions
{
    public class PackingItemNotFoundException : PackItException
    {
        public string ItemName { get; }

        public PackingItemNotFoundException(string itemName) : base($"Packing item '${itemName}' was not found.")
            => ItemName = itemName;
    }
}
