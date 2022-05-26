using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PcAssembly.Bll;
using PcAssembly.Bll.Exeptions;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Common.Dtos.Assembly;
using PcAssembly.Common.Dtos.CPU;
using PcAssembly.Common.Dtos.User;
using PcAssembly.Common.Models;
using PcAssembly.Common.Models.PagedRequest;


namespace PcAssembly.Controllers
{
    [Route("api/[controller]")]
        [ApiController]
    public class AssembliesController : ControllerBase
    {
        private readonly IAssemblyService _assemblyService;

        public AssembliesController(IAssemblyService assemblyService)
        {
            _assemblyService = assemblyService;

        }

        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<GetAssemblyDto>> GetPagedAssemblies(PagedRequest pagedRequest)
        {
            return await _assemblyService.GetPagedAssemblies(pagedRequest);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = RolesNames.Administrator)]
        public async Task<ActionResult<ServiceResponse<GetAssemblyDto>>> DeleteAssembly(Guid id)
        {
            var response = await _assemblyService.DeleteAssembly(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetAssemblyDto>>> CreateAssembly([FromBody] AddAssemblyDto assemblyDto)
        {
            var response = await _assemblyService.CreateAssembly(assemblyDto);
            if (response.Data == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetAssemblyDto>>>> GetAssemblies()
        {
            return Ok(await _assemblyService.GetAssemblies());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetAssemblyDto>> GetAssemblyById(Guid id)
        {
            var result = await _assemblyService.GetAssemblyById(id);
            return Ok(result);
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<GetAssemblyDto>>> UpdateAssembly(Guid id, [FromBody] UpdateAssemblyDto updatedAssembly)
        {
            var response = await _assemblyService.UpdateAssembly(id, updatedAssembly);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("Generate/{price}")]
        public async Task<ActionResult<GetAssemblyDto>> GetGeneratedAssembly(double price)
        {
            try
            {
                var result = await _assemblyService.GenerateAssembly(price);
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
