using Microsoft.AspNetCore.Mvc;
using PcAssembly.Bll;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Common.Dtos.CPU;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PcAssembly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuController : ControllerBase
    {
        private readonly ICpuService _cpuService;

        public CpuController(ICpuService cpuService)
        {
            _cpuService = cpuService;

        }

        // GET: api/<CpuController>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetCpuDto>>>> Get()
        {
            //return cpuList;
            return Ok(await _cpuService.GetAllCPUs());
        }

        // GET api/<CpuController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCpuDto>>> GetSingle(int id)
        {
            //return cpuList.FirstOrDefault(cpu => cpu.Id == id);
            return Ok(await _cpuService.GetCpuById(id));
        }

        // POST api/<CpuController>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCpuDto>>>> AddCPU([FromBody] AddCpuDto newCPU)
        {
            return Ok(await _cpuService.AddCPU(newCPU));
        }

        // PUT api/<CpuController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCpuDto>>>> UpdateCPU(int id, [FromBody] UpdateCpuDto updatedCPU)
        {

            var response = await _cpuService.UpdateCPU(id,updatedCPU);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }

        // DELETE api/<CpuController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCpuDto>>>> Delete(int id)
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
