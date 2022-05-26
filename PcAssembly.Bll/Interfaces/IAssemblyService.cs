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
        Task<ServiceResponse<GetAssemblyDto>> DeleteAssembly(Guid id);
        Task<ServiceResponse<GetAssemblyDto>> CreateAssembly(AddAssemblyDto assemblyDto);
        Task<ServiceResponse<List<GetAssemblyDto>>> GetAssemblies();
        Task<GetAssemblyDto> GetAssemblyById(Guid id);
        Task<GenerateAssemblyDto> GenerateAssembly(double price);
        Task<ServiceResponse<GetAssemblyDto>> UpdateAssembly(Guid id, UpdateAssemblyDto updatedAssembly);
    }
}
