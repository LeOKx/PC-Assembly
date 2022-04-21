using Microsoft.AspNetCore.Mvc;
using PcAssembly.Bll;
using PcAssembly.Bll.Exeptions;
using PcAssembly.Bll.Filters;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Common.Dtos.CPU;

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
        public async Task<ActionResult<ServiceResponse<List<GetCpuDto>>>> Get([FromQuery] SearchOptions searchOption)
        {

            //return cpuList;
            return Ok(await _cpuService.GetCPUs(searchOption));
        }

        // GET api/<CpuController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCpuDto>>> GetSingle(Guid id)
        {
            //return cpuList.FirstOrDefault(cpu => cpu.Id == id);
            return Ok(await _cpuService.GetCpuById(id));
        }

        // POST api/<CpuController>
        [HttpPost]
        [ApiExceptionFilter]
        public async Task<ActionResult<ServiceResponse<List<GetCpuDto>>>> AddCPU([FromBody] AddCpuDto newCPU)
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
        [ApiExceptionFilter]
        public async Task<ActionResult<ServiceResponse<List<GetCpuDto>>>> UpdateCPU(Guid id, [FromBody] UpdateCpuDto updatedCPU)
        {

            var response = await _cpuService.UpdateCPU(id,updatedCPU);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }

        [HttpPatch("{id}")]
        [ApiExceptionFilter]
        public async Task<ActionResult<ServiceResponse<List<GetCpuDto>>>> PatchCPU(Guid id, [FromBody] UpdateCpuDto updatedCPU)
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
        public async Task<ActionResult<ServiceResponse<List<GetCpuDto>>>> Delete(Guid id)
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
