using Microsoft.AspNetCore.Mvc;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Domain;

namespace PcAssembly.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private IImageService _service;
        public ImageController(IImageService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm(Name = "image")] IFormFile file)
        {
            string image = await _service.SaveImage(file);
            return Ok($"https://localhost:7144/api/images/{image}"); 
            
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