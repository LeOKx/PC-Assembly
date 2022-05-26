using Microsoft.AspNetCore.Mvc;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Common.Dtos.Image;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Domain;

namespace PcAssembly.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private IImageService _service;
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _pathConfig;

        public ImageController(IImageService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
            _pathConfig = _configuration.GetSection("ImageBasePath");
        }

        [HttpPost]
        public async Task<GetImageDto> Post([FromForm(Name = "image")] IFormFile file)
        {
            
            string image = await _service.SaveImage(file);
            string path = _pathConfig.GetSection("ApiImagePath").Value;

            GetImageDto getImageDto = new GetImageDto()
            {
                ImageUrl = $"{path}{image}"
            };

            return getImageDto;


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var image = await _service.GetImage(id);
            if (image == null)
            {
                return NotFound();
            }
            return File(image.Data, "image/png");
        }
    }
}