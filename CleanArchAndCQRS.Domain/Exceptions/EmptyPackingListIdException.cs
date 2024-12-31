using CleanArchAndCQRS.Shared.Abstractions.Exceptions;

namespace CleanArchAndCQRS.Domain.Exceptions
{
    public class EmptyPackingListIdException : PackItException
    {
        public EmptyPackingListIdException() : base("Packing list Id cannot be empty.")
        {
        }
    }
}
