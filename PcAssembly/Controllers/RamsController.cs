using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PcAssembly.Bll;
using PcAssembly.Bll.Exeptions;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Common.Dtos.RAM;
using PcAssembly.Common.Dtos.User;
using PcAssembly.Common.Models;
using PcAssembly.Common.Models.PagedRequest;


namespace PcAssembly.Controllers
{
    [Route("api/[controller]")]
        [ApiController]
    public class RamsController : ControllerBase
    {
        private readonly IRamService _ramService;

        public RamsController(IRamService ramService)
        {
            _ramService = ramService;

        }

                [HttpGet]
                public async Task<ActionResult<ServiceResponse<List<GetRamDto>>>> Get()
        {

                        return Ok(await _ramService.GetRams());
        }

        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<GetRamDto>> GetPagedRams(PagedRequest pagedRequest)
        {
            return await _ramService.GetPagedRams(pagedRequest);
        }

                [HttpGet("{id}")]
        
        public async Task<ActionResult<GetRamDto>> GetSingle(Guid id)
        {
                        return Ok(await _ramService.GetRamById(id));
        }

                [HttpPost]
        [Authorize(Roles = RolesNames.Administrator)]
        [ApiExceptionFilter]
        public async Task<ActionResult<ServiceResponse<List<GetRamDto>>>> AddRam([FromBody] AddRamDto newRam)
        {
            var response = await _ramService.AddRam(newRam);
            if (response.Data == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

                [HttpPut("{id}")]
        [Authorize(Roles = RolesNames.Administrator)]
        [ApiExceptionFilter]
        public async Task<ActionResult<ServiceResponse<List<GetRamDto>>>> UpdateRam(Guid id, [FromBody] UpdateRamDto updatedRam)
        {

            var response = await _ramService.UpdateRam(id,updatedRam);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }

        [HttpPatch("{id}")]
        [Authorize(Roles = RolesNames.Administrator)]
        [ApiExceptionFilter]
        public async Task<ActionResult<ServiceResponse<List<GetRamDto>>>> PatchRam(Guid id, [FromBody] UpdateRamDto updatedRam)
        {

            var response = await _ramService.UpdateRam(id, updatedRam);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }

                [HttpDelete("{id}")]
        [Authorize(Roles = RolesNames.Administrator)]
        public async Task<ActionResult<ServiceResponse<List<GetRamDto>>>> Delete(Guid id)
        {
            var response = await _ramService.DeleteRam(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
