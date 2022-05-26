using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PcAssembly.Bll;
using PcAssembly.Bll.Exeptions;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Common.Dtos.PowerSupply;
using PcAssembly.Common.Dtos.User;
using PcAssembly.Common.Models;
using PcAssembly.Common.Models.PagedRequest;


namespace PcAssembly.Controllers
{
    [Route("api/[controller]")]
        [ApiController]
    public class PowerSuppliesController : ControllerBase
    {
        private readonly IPowerSupplyService _powerSupplyService;

        public PowerSuppliesController(IPowerSupplyService powerSupplyService)
        {
            _powerSupplyService = powerSupplyService;

        }

                [HttpGet]
                public async Task<ActionResult<ServiceResponse<List<GetPowerSupplyDto>>>> Get()
        {

                        return Ok(await _powerSupplyService.GetPowerSupplies());
        }

        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<GetPowerSupplyDto>> GetPagedPowerSupplys(PagedRequest pagedRequest)
        {
            return await _powerSupplyService.GetPagedPowerSupplies(pagedRequest);
        }

                [HttpGet("{id}")]
        
        public async Task<ActionResult<GetPowerSupplyDto>> GetSingle(Guid id)
        {
                        return Ok(await _powerSupplyService.GetPowerSupplyById(id));
        }

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
