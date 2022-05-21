using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PcAssembly.Bll;
using PcAssembly.Bll.Exeptions;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Common.Dtos.PowerSupply;
using PcAssembly.Common.Dtos.User;
using PcAssembly.Common.Models;
using PcAssembly.Common.Models.PagedRequest;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PcAssembly.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class PowerSuppliesController : ControllerBase
    {
        private readonly IPowerSupplyService _powerSupplyService;

        public PowerSuppliesController(IPowerSupplyService powerSupplyService)
        {
            _powerSupplyService = powerSupplyService;

        }

        // GET: api/<PowerSupplyController>
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<ServiceResponse<List<GetPowerSupplyDto>>>> Get()
        {

            //return powerSupplyList;
            return Ok(await _powerSupplyService.GetPowerSupplies());
        }

        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<GetPowerSupplyDto>> GetPagedPowerSupplys(PagedRequest pagedRequest)
        {
            return await _powerSupplyService.GetPagedPowerSupplies(pagedRequest);
        }

        // GET api/<PowerSupplyController>/5
        [HttpGet("{id}")]
        
        public async Task<ActionResult<GetPowerSupplyDto>> GetSingle(Guid id)
        {
            //return powerSupplyList.FirstOrDefault(powerSupply => powerSupply.Id == id);
            return Ok(await _powerSupplyService.GetPowerSupplyById(id));
        }

        // POST api/<PowerSupplyController>
        [HttpPost]
        [Authorize(Roles = RolesNames.Administrator)]
        [ApiExceptionFilter]
        public async Task<ActionResult<ServiceResponse<List<GetPowerSupplyDto>>>> AddPowerSupply([FromBody] AddPowerSupplyDto newPowerSupply)
        {
            var response = await _powerSupplyService.AddPowerSupply(newPowerSupply);
            if (response.Data == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        // PUT api/<PowerSupplyController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = RolesNames.Administrator)]
        [ApiExceptionFilter]
        public async Task<ActionResult<ServiceResponse<List<GetPowerSupplyDto>>>> UpdatePowerSupply(Guid id, [FromBody] UpdatePowerSupplyDto updatedPowerSupply)
        {

            var response = await _powerSupplyService.UpdatePowerSupply(id,updatedPowerSupply);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }

        [HttpPatch("{id}")]
        [Authorize(Roles = RolesNames.Administrator)]
        [ApiExceptionFilter]
        public async Task<ActionResult<ServiceResponse<List<GetPowerSupplyDto>>>> PatchPowerSupply(Guid id, [FromBody] UpdatePowerSupplyDto updatedPowerSupply)
        {

            var response = await _powerSupplyService.UpdatePowerSupply(id, updatedPowerSupply);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }

        // DELETE api/<PowerSupplyController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = RolesNames.Administrator)]
        public async Task<ActionResult<ServiceResponse<List<GetPowerSupplyDto>>>> Delete(Guid id)
        {
            var response = await _powerSupplyService.DeletePowerSupply(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
