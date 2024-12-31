using CleanArchAndCQRS.Application.DTO;
using CleanArchAndCQRS.Shared.Abstractions.Queries;

namespace CleanArchAndCQRS.Application.Queries
{
    public class SearchPackingLists : IQuery<IEnumerable<PackingListDto>>
    {
        public string SearchPhrase { get; set; }
    }
}
