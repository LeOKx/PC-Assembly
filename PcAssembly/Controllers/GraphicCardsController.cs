using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PcAssembly.Bll;
using PcAssembly.Bll.Exeptions;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Common.Dtos.GraphicCard;
using PcAssembly.Common.Dtos.User;
using PcAssembly.Common.Models;
using PcAssembly.Common.Models.PagedRequest;


namespace PcAssembly.Controllers
{
    [Route("api/[controller]")]
        [ApiController]
    public class GraphicCardsController : ControllerBase
    {
        private readonly IGraphicCardService _graphicCardService;

        public GraphicCardsController(IGraphicCardService graphicCardService)
        {
            _graphicCardService = graphicCardService;

        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetGraphicCardDto>>>> Get()
        {

                        return Ok(await _graphicCardService.GetGPUs());
        }

        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<GetGraphicCardDto>> GetPagedGraphicCards(PagedRequest pagedRequest)
        {
            return await _graphicCardService.GetPagedGraphicCards(pagedRequest);
        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<GetGraphicCardDto>> GetSingle(Guid id)
        {
                        return Ok(await _graphicCardService.GetGraphicCardById(id));
        }

        [HttpPost]
        [Authorize(Roles = RolesNames.Administrator)]
        [ApiExceptionFilter]
        public async Task<ActionResult<ServiceResponse<List<GetGraphicCardDto>>>> AddGraphicCard([FromBody] AddGraphicCardDto newGraphicCard)
        {
            var response = await _graphicCardService.AddGraphicCard(newGraphicCard);
            if (response.Data == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = RolesNames.Administrator)]
        [ApiExceptionFilter]
        public async Task<ActionResult<ServiceResponse<List<GetGraphicCardDto>>>> UpdateGraphicCard(Guid id, [FromBody] UpdateGraphicCardDto updatedGraphicCard)
        {

            var response = await _graphicCardService.UpdateGraphicCard(id,updatedGraphicCard);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }

        [HttpPatch("{id}")]
        [Authorize(Roles = RolesNames.Administrator)]
        [ApiExceptionFilter]
        public async Task<ActionResult<ServiceResponse<List<GetGraphicCardDto>>>> PatchGraphicCard(Guid id, [FromBody] UpdateGraphicCardDto updatedGraphicCard)
        {

            var response = await _graphicCardService.UpdateGraphicCard(id, updatedGraphicCard);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }

                [HttpDelete("{id}")]
        [Authorize(Roles = RolesNames.Administrator)]
        public async Task<ActionResult<ServiceResponse<List<GetGraphicCardDto>>>> Delete(Guid id)
        {
            var response = await _graphicCardService.DeleteGraphicCard(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
