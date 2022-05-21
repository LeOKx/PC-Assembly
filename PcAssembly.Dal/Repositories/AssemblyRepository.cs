using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PcAssembly.Common.Dtos.Assembly;
using PcAssembly.Common.Models.PagedRequest;
using PcAssembly.Dal.Extensions;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Dal.Repositories
{
    public class AssemblyRepository : GenericRepository<Assembly, Guid>, IAssemblyRepository
    {
        public AssemblyRepository(DataContext _context, IMapper _mapper) : base(_context, _mapper)
        {
        }

        public async Task<PaginatedResult<GetAssemblyDto>> GetPagedAssembliesWithDetails(PagedRequest pagedRequest)
        {
            return await _context.Set<Assembly>()
                .Include(x => x.Cpu)
                .Include(x => x.GraphicCard)
                .Include(x => x.Motherboard)
                .Include(x => x.PowerSupply)
                .Include(x => x.Ram)
                .CreatePaginatedResultAsync<Assembly, GetAssemblyDto>(pagedRequest, _mapper);
        }
        public async Task<bool> ExistAssemblyWithName(string name)
        {
            var assembly = await DbSet
                .FirstOrDefaultAsync(c => c.Name == name);
            if (assembly == null)
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
