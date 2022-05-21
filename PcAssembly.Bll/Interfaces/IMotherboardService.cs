
using PcAssembly.Common.Dtos.CPU;
using PcAssembly.Common.Dtos.Motherboard;
using PcAssembly.Common.Models;
using PcAssembly.Common.Models.PagedRequest;

namespace PcAssembly.Bll.Interfaces
{
    public interface IMotherboardService
    {
        Task<ServiceResponse<List<GetMotherboardDto>>> GetMotherboards();
        Task<PaginatedResult<GetMotherboardDto>> GetPagedMotherboards(PagedRequest pagedRequest);
        Task<GetMotherboardDto> GetMotherboardById(Guid id);
        Task<ServiceResponse<GetMotherboardDto>> AddMotherboard(AddMotherboardDto newMotherboard);
        Task<ServiceResponse<GetMotherboardDto>> UpdateMotherboard(Guid id, UpdateMotherboardDto updatedMotherboard);
        Task<ServiceResponse<GetMotherboardDto>> DeleteMotherboard(Guid id);
    }
}
