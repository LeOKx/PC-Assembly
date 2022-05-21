
using PcAssembly.Common.Dtos.RAM;
using PcAssembly.Common.Models;
using PcAssembly.Common.Models.PagedRequest;

namespace PcAssembly.Bll.Interfaces
{
    public interface IRamService
    {
        Task<ServiceResponse<List<GetRamDto>>> GetRams();
        Task<PaginatedResult<GetRamDto>> GetPagedRams(PagedRequest pagedRequest);
        Task<GetRamDto> GetRamById(Guid id);
        Task<ServiceResponse<GetRamDto>> AddRam(AddRamDto newRam);
        Task<ServiceResponse<GetRamDto>> UpdateRam(Guid id, UpdateRamDto updatedRam);
        Task<ServiceResponse<GetRamDto>> DeleteRam(Guid id);
    }
}
