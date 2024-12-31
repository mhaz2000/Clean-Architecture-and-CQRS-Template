using CleanArchAndCQRS.Shared.Abstractions.Exceptions;

namespace CleanArchAndCQRS.Application.Exceptions
{
    public class PackingListNotFoundException : PackItException
    {
        public PackingListNotFoundException() : base("Pack list cannot be found.")
        {
        }
    }
}
