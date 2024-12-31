using CleanArchAndCQRS.Shared.Abstractions.Exceptions;

namespace CleanArchAndCQRS.Domain.Exceptions
{
    public class EmptyPackingListNameException : PackItException
    {
        public EmptyPackingListNameException() : base("Packing list name cannot be empty.")
        {
        }
    }
}
