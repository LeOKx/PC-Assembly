
using PcAssembly.Common.Dtos.GraphicCard;
using PcAssembly.Common.Models;
using PcAssembly.Common.Models.PagedRequest;

namespace PcAssembly.Bll.Interfaces
{
    public interface IGraphicCardService
    {
        Task<ServiceResponse<List<GetGraphicCardDto>>> GetGPUs();
        Task<PaginatedResult<GetGraphicCardDto>> GetPagedGraphicCards(PagedRequest pagedRequest);
        Task<GetGraphicCardDto> GetGraphicCardById(Guid id);
        Task<ServiceResponse<GetGraphicCardDto>> AddGraphicCard(AddGraphicCardDto newGraphicCard);
        Task<ServiceResponse<GetGraphicCardDto>> UpdateGraphicCard(Guid id, UpdateGraphicCardDto updatedGraphicCard);
        Task<ServiceResponse<GetGraphicCardDto>> DeleteGraphicCard(Guid id);
    }
}
