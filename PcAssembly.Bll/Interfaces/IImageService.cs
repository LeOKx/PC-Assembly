using Microsoft.AspNetCore.Http;
using PcAssembly.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Bll.Interfaces
{
    public interface IImageService
    {
        Task<string> SaveImage(IFormFile file);
        Task<Image> GetImage(Guid id);
    }
}
