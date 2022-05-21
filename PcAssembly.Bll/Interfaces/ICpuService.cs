
using PcAssembly.Common.Dtos.CPU;
using PcAssembly.Common.Models;
using PcAssembly.Common.Models.PagedRequest;

namespace PcAssembly.Bll.Interfaces
{
    public interface ICpuService
    {
        Task<ServiceResponse<List<GetCpuDto>>> GetCPUs();
        Task<PaginatedResult<GetCpuDto>> GetPagedCpus(PagedRequest pagedRequest);
        Task<GetCpuDto> GetCpuById(Guid id);
        Task<ServiceResponse<GetCpuDto>> AddCPU(AddCpuDto newCPU);
        Task<ServiceResponse<GetCpuDto>> UpdateCPU(Guid id, UpdateCpuDto updatedCPU);
        Task<ServiceResponse<GetCpuDto>> DeleteCPU(Guid id);
    }
}
