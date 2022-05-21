
using PcAssembly.Common.Dtos.PowerSupply;
using PcAssembly.Common.Models;
using PcAssembly.Common.Models.PagedRequest;

namespace PcAssembly.Bll.Interfaces
{
    public interface IPowerSupplyService
    {
        Task<ServiceResponse<List<GetPowerSupplyDto>>> GetPowerSupplies();
        Task<PaginatedResult<GetPowerSupplyDto>> GetPagedPowerSupplies(PagedRequest pagedRequest);
        Task<GetPowerSupplyDto> GetPowerSupplyById(Guid id);
        Task<ServiceResponse<GetPowerSupplyDto>> AddPowerSupply(AddPowerSupplyDto newPowerSupply);
        Task<ServiceResponse<GetPowerSupplyDto>> UpdatePowerSupply(Guid id, UpdatePowerSupplyDto updatedPowerSupply);
        Task<ServiceResponse<GetPowerSupplyDto>> DeletePowerSupply(Guid id);
    }
}
