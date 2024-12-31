using CleanArchAndCQRS.Application.DTO;
using CleanArchAndCQRS.Shared.Abstractions.Queries;

namespace CleanArchAndCQRS.Application.Queries
{
    public class GetPackingList : IQuery<PackingListDto>
    {
        public Guid Id { get; set; }
    }
}
