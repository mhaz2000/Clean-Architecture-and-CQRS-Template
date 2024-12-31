using CleanArchAndCQRS.Application.DTO;
using CleanArchAndCQRS.Application.Queries;
using CleanArchAndCQRS.Infrastructure.EF.Contexts;
using CleanArchAndCQRS.Infrastructure.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchAndCQRS.Infrastructure.Queries.Handlers
{
    internal sealed class GetPackingListHandler : IRequestHandler<GetPackingList, PackingListDto?>
    {
        private readonly DbSet<PackingListReadModel> _packingList;

        public GetPackingListHandler(ReadDbContext context)
            => _packingList = context.PackingLists;

        public async Task<PackingListDto?> Handle(GetPackingList query, CancellationToken cancellationToken)
            => await _packingList.Include(pl=> pl.Items)
                .Where(pl=> pl.Id == query.Id)
                .Select(pl=> pl.AsDto())
                .AsNoTracking()
                .SingleOrDefaultAsync(cancellationToken);
    }
}
