using CleanArchAndCQRS.Shared.Abstractions.Exceptions;

namespace CleanArchAndCQRS.Domain.Exceptions
{
    public class PackingItemAlreadyExistsException : PackItException
    {
        public string ListName { get; }
        public string ItemName { get; }

        public PackingItemAlreadyExistsException(string listName, string itemName) 
            : base($"Packing List: '{listName}' already defined item '${itemName}'")
        {
            ListName = listName;

            ItemName = itemName;
        }
    }
}
