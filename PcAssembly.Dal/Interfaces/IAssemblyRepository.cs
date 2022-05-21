using PcAssembly.Common.Dtos.Assembly;
using PcAssembly.Common.Models.PagedRequest;
using PcAssembly.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Dal.Interfaces
{
    public interface IAssemblyRepository : IGenericRepository<Assembly, Guid>
    {
        Task<PaginatedResult<GetAssemblyDto>> GetPagedAssembliesWithDetails(PagedRequest pagedRequest);
        Task<bool> ExistAssemblyWithName(string name);
    }
}
