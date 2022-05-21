using PcAssembly.Common.Dtos.Assembly;
using PcAssembly.Common.Models.PagedRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Bll.Interfaces
{
    public interface IAssemblyService
    {
        Task<PaginatedResult<GetAssemblyDto>> GetPagedAssemblies(PagedRequest pagedRequest);
        Task<ServiceResponse<GetAssemblyDto>> CreateAssembly(AddAssemblyDto assemblyDto);
    }
}
