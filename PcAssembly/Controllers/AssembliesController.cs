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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PcAssembly.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
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
    }
}
