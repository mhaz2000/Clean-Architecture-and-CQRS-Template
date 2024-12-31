using CleanArchAndCQRS.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchAndCQRS.Application.Queries.Handlers
{
    public class GetPackingListHandler : IRequestHandler<GetPackingList, PackingListDto>
    {
        public Task<PackingListDto> Handle(GetPackingList query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
