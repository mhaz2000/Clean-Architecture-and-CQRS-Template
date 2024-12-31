using CleanArchAndCQRS.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchAndCQRS.Application.Services
{
    public interface IPackingListReadService
    {
        Task<bool> ExistsByNameAsync(string name);
    }
}
