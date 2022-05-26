using Microsoft.AspNetCore.Http;
using PcAssembly.Bll.Interfaces;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Bll.Services
{
    public class ImageService : IImageService
    {
        private IGenericRepository<Image, Guid> _repo;
        public ImageService(IGenericRepository<Image, Guid> repo)
        {
            _repo = repo;
        }
        public async Task<Image> GetImage(Guid id)
        {
            return await _repo.GetById(id);
        }

        public async Task<string> SaveImage(IFormFile file)
        {
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                var image = new Image { Data = stream.ToArray() };
                image = await _repo.Insert(image);
                await _repo.SaveChangesAsync();
                return $"{image.Id}";
            }
        }
    }
}
