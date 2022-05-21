using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PcAssembly.Bll;
using PcAssembly.Bll.Exeptions;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Common.Dtos.CPU;
using PcAssembly.Common.Dtos.User;
using PcAssembly.Common.Models;
using PcAssembly.Common.Models.PagedRequest;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PcAssembly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpusController : ControllerBase
    {
        private readonly ICpuService _cpuService;

        public CpusController(ICpuService cpuService)
        {
            _cpuService = cpuService;

        }

        // GET: api/<CpuController>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetCpuDto>>>> Get()
        {

            //return cpuList;
            return Ok(await _cpuService.GetCPUs());
        }

        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<GetCpuDto>> GetPagedCpus(PagedRequest pagedRequest)
        {
            return await _cpuService.GetPagedCpus(pagedRequest);
        }

        // GET api/<CpuController>/5
        [HttpGet("{id}")]
        
        public async Task<ActionResult<GetCpuDto>> GetSingle(Guid id)
        {
            //return cpuList.FirstOrDefault(cpu => cpu.Id == id);
            return Ok(await _cpuService.GetCpuById(id));
        }

        // POST api/<CpuController>
        [HttpPost]
        [Authorize(Roles = RolesNames.Administrator)]
        [ApiExceptionFilter]
        public async Task<ActionResult<ServiceResponse<GetCpuDto>>> AddCPU([FromBody] AddCpuDto newCPU)
        {
            var response = await _cpuService.AddCPU(newCPU);
            if (response.Data == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        // PUT api/<CpuController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = RolesNames.Administrator)]
        [ApiExceptionFilter]
        public async Task<ActionResult<ServiceResponse<GetCpuDto>>> UpdateCPU(Guid id, [FromBody] UpdateCpuDto updatedCPU)
        {

            var response = await _cpuService.UpdateCPU(id,updatedCPU);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }

        [HttpPatch("{id}")]
        [Authorize(Roles = RolesNames.Administrator)]
        [ApiExceptionFilter]
        public async Task<ActionResult<ServiceResponse<GetCpuDto>>> PatchCPU(Guid id, [FromBody] UpdateCpuDto updatedCPU)
        {

            var response = await _cpuService.UpdateCPU(id, updatedCPU);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }

        // DELETE api/<CpuController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = RolesNames.Administrator)]
        public async Task<ActionResult<ServiceResponse<GetCpuDto>>> Delete(Guid id)
        {
            var response = await _cpuService.DeleteCPU(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
