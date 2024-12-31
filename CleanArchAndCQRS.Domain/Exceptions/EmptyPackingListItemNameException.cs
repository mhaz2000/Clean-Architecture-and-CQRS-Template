using CleanArchAndCQRS.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchAndCQRS.Domain.Exceptions
{
    public class EmptyPackingListItemNameException : PackItException
    {
        public EmptyPackingListItemNameException() : base("Packing list item cannot be empty.")
        {
        }
    }
}
