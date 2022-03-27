using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Domain;

namespace PcAssembly.Dal.Repositories
{
    public class CpuRepository : ComponentRepository<CPU>, ICpuRepository
    {
        public CpuRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> ExistCpuWithTheModel(string model)
        {
            var component = await _context.CPUs
                .Include(c => c.ManufacturerInfo)
                .FirstOrDefaultAsync(c => c.ManufacturerInfo.Model == model);
            if (component == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
