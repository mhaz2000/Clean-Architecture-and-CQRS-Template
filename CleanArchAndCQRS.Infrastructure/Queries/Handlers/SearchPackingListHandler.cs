using CleanArchAndCQRS.Application.DTO;
using CleanArchAndCQRS.Application.Queries;
using CleanArchAndCQRS.Infrastructure.EF.Contexts;
using CleanArchAndCQRS.Infrastructure.Models;
using CleanArchAndCQRS.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace CleanArchAndCQRS.Infrastructure.Queries.Handlers
{
    internal sealed class SearchPackingListHandler : IQueryHandler<SearchPackingLists, IEnumerable<PackingListDto>>
    {
        private readonly DbSet<PackingListReadModel> _packingList;

        public SearchPackingListHandler(ReadDbContext context)
            => _packingList = context.PackingLists;

        public async Task<IEnumerable<PackingListDto>> Handle(SearchPackingLists query, CancellationToken cancellationToken)
        {
            var dbQuery = _packingList.Include(c => c.Items).AsQueryable();

            if (!string.IsNullOrEmpty(query.SearchPhrase))
                dbQuery = dbQuery
                    .Where(pl => Microsoft.EntityFrameworkCore.EF.Functions.Like(pl.Name, $"%{query.SearchPhrase}%"));

            return await dbQuery
                .Select(pl => pl.AsDto())
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
