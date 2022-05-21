using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Domain;
using PcAssembly.Domain.Components;

namespace PcAssembly.Dal.Repositories
{
    public class RamRepository : ComponentRepository<Ram>, IRamRepository
    {
        public RamRepository(DataContext _context, IMapper _mapper) : base(_context, _mapper)
        {


        }
        
 
    }
}
