using PcAssembly.Bll.Filters;
using PcAssembly.Common.Dtos.CPU;

namespace PcAssembly.Bll.Interfaces
{
    public interface ICpuService
    {
        Task<ServiceResponse<List<GetCpuDto>>> GetCPUs(SearchOptions searchOptions);
        Task<ServiceResponse<GetCpuDto>> GetCpuById(Guid id);
        Task<ServiceResponse<GetCpuDto>> AddCPU(AddCpuDto newCPU);
        Task<ServiceResponse<GetCpuDto>> UpdateCPU(Guid id, UpdateCpuDto updatedCPU);
        Task<ServiceResponse<GetCpuDto>> DeleteCPU(Guid id);
    }
}
