using PcAssembly.Common.Dtos.CPU;

namespace PcAssembly.Bll.Interfaces
{
    public interface ICpuService
    {
        Task<ServiceResponse<List<GetCpuDto>>> GetAllCPUs();
        Task<ServiceResponse<GetCpuDto>> GetCpuById(int id);
        Task<ServiceResponse<GetCpuDto>> AddCPU(AddCpuDto newCPU);
        Task<ServiceResponse<GetCpuDto>> UpdateCPU(int id, UpdateCpuDto updatedCPU);
        Task<ServiceResponse<GetCpuDto>> DeleteCPU(int id);
    }
}
