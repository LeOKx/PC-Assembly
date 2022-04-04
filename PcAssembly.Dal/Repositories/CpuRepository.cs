using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Domain;
using PcAssembly.Domain.Components;

namespace PcAssembly.Dal.Repositories
{
    public class CpuRepository: ComponentRepository<CPU, int>, ICpuRepository
    {
        public CpuRepository(DataContext context) : base(context)
        {
        }

 
    }
}
