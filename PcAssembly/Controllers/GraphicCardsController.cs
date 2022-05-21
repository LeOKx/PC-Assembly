using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PcAssembly.Bll;
using PcAssembly.Bll.Exeptions;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Common.Dtos.GraphicCard;
using PcAssembly.Common.Dtos.User;
using PcAssembly.Common.Models;
using PcAssembly.Common.Models.PagedRequest;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PcAssembly.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class GraphicCardsController : ControllerBase
    {
        private readonly IGraphicCardService _graphicCardService;

        public GraphicCardsController(IGraphicCardService graphicCardService)
        {
            _graphicCardService = graphicCardService;

        }

        // GET: api/<GraphicCardController>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetGraphicCardDto>>>> Get()
        {

            //return graphicCardList;
            return Ok(await _graphicCardService.GetGPUs());
        }

        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<GetGraphicCardDto>> GetPagedGraphicCards(PagedRequest pagedRequest)
        {
            return await _graphicCardService.GetPagedGraphicCards(pagedRequest);
        }

        // GET api/<GraphicCardController>/5
        [HttpGet("{id}")]
        
        public async Task<ActionResult<GetGraphicCardDto>> GetSingle(Guid id)
        {
            //return graphicCardList.FirstOrDefault(graphicCard => graphicCard.Id == id);
            return Ok(await _graphicCardService.GetGraphicCardById(id));
        }

        // POST api/<GraphicCardController>
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

        // PUT api/<GraphicCardController>/5
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

        // DELETE api/<GraphicCardController>/5
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
