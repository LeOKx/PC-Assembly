using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PcAssembly.Bll;
using PcAssembly.Bll.Exeptions;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Common.Dtos.Motherboard;
using PcAssembly.Common.Dtos.User;
using PcAssembly.Common.Models;
using PcAssembly.Common.Models.PagedRequest;


namespace PcAssembly.Controllers
{
    [Route("api/[controller]")]
        [ApiController]
    public class MotherboardsController : ControllerBase
    {
        private readonly IMotherboardService _motherboardService;

        public MotherboardsController(IMotherboardService motherboardService)
        {
            _motherboardService = motherboardService;

        }

                [HttpGet]
                public async Task<ActionResult<ServiceResponse<List<GetMotherboardDto>>>> Get()
        {

                        return Ok(await _motherboardService.GetMotherboards());
        }

        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<GetMotherboardDto>> GetPagedMotherboards(PagedRequest pagedRequest)
        {
            return await _motherboardService.GetPagedMotherboards(pagedRequest);
        }

                [HttpGet("{id}")]
        
        public async Task<ActionResult<GetMotherboardDto>> GetSingle(Guid id)
        {
            return Ok(await _motherboardService.GetMotherboardById(id));
        }

                [HttpPost]
        [Authorize(Roles = RolesNames.Administrator)]
        [ApiExceptionFilter]
        public async Task<ActionResult<ServiceResponse<List<GetMotherboardDto>>>> AddMotherboard([FromBody] AddMotherboardDto newMotherboard)
        {
            var response = await _motherboardService.AddMotherboard(newMotherboard);
            if (response.Data == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

                [HttpPut("{id}")]
        [Authorize(Roles = RolesNames.Administrator)]
        [ApiExceptionFilter]
        public async Task<ActionResult<ServiceResponse<List<GetMotherboardDto>>>> UpdateMotherboard(Guid id, [FromBody] UpdateMotherboardDto updatedMotherboard)
        {

            var response = await _motherboardService.UpdateMotherboard(id,updatedMotherboard);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }

        [HttpPatch("{id}")]
        [Authorize(Roles = RolesNames.Administrator)]
        [ApiExceptionFilter]
        public async Task<ActionResult<ServiceResponse<List<GetMotherboardDto>>>> PatchMotherboard(Guid id, [FromBody] UpdateMotherboardDto updatedMotherboard)
        {

            var response = await _motherboardService.UpdateMotherboard(id, updatedMotherboard);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = RolesNames.Administrator)]
        public async Task<ActionResult<ServiceResponse<List<GetMotherboardDto>>>> Delete(Guid id)
        {
            var response = await _motherboardService.DeleteMotherboard(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
