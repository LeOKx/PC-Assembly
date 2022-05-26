using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PcAssembly.Common.Dtos.Assembly;
using PcAssembly.Common.Models.PagedRequest;
using PcAssembly.Dal.Extensions;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Domain;
using PcAssembly.Domain.Components;
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

        public async Task<List<Assembly>> GetAllWithDetails()
        {
            var result = await _context.Set<Assembly>()
                .Include(x => x.Cpu)
                .Include(x => x.GraphicCard)
                .Include(x => x.Motherboard)
                .Include(x => x.PowerSupply)
                .Include(x => x.Ram)
                .ToListAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Haven't Assembly in Data Base");
            }
        }

        public async Task<Assembly> GetByIdWithDetails(Guid id)
        {
            var result = await _context.Set<Assembly>()
                .Include(x => x.Cpu)
                .Include(x => x.GraphicCard)
                .Include(x => x.Motherboard)
                .Include(x => x.PowerSupply)
                .Include(x => x.Ram)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Haven't Assembly with this id in Data Base");
            }

        }

        public async Task<Assembly> GenereateAssembly(double price)
        {
            bool find = true;

            const double cpuPercent = 0.1;
            const double gpuPercent = 0.60;
            const double motherboardPercent = 0.1;
            const double powerSupplyPercent = 0.07;
            const double ramPercent = 0.1;
            double? remaining;
            int? power;

            int coolersCount = (int)(((price * 0.03) - 2000) / 200);
            if (coolersCount <= 0)
                coolersCount = 1;
            if(coolersCount > 10)
                coolersCount = 10;

            CPU? cpu = new CPU();
            Motherboard? motherboard = new Motherboard();
            PowerSupply? powerSupply = new PowerSupply();
            Ram? ram = new Ram();


            var gpu = await GetGraphicCardAsync(gpuPercent, price);
            if (gpu != null)
            {
                power = gpu.PowerConsumption;
                remaining = (price*gpuPercent - gpu.Price);
                cpu = await GetCpuAsync(cpuPercent, price, remaining);
                if(cpu != null)
                {
                    power += cpu.PowerConsumption;
                    remaining = ((price * cpuPercent) + remaining - cpu.Price);
                    motherboard = await GetMotherboardAsync(motherboardPercent, price, remaining, cpu.Socket);
                    if(motherboard != null)
                    {
                        power += motherboard.PowerConsumption;
                        remaining = ((price * motherboardPercent) + remaining - motherboard.Price);
                        ram = await GetRamAsync(ramPercent, price, remaining, motherboard.RamType, motherboard.RamSlots);
                        if(ram != null)
                        {
                            power += ram.PowerConsumption;
                            remaining = ((price * ramPercent) + remaining - ram.Price);
                            powerSupply = await GetPowerSupplyAsync(powerSupplyPercent, price, remaining, power);
                            if(powerSupply == null)
                                find = false;
                        }
                        else
                            find = false;
                    }
                    else
                        find = false;
                }
                else
                    find = false;
            }
            else
            {
                find = false;
            }

            if(find == true)
            {
                var assembly = new Assembly()
                {
                    Cpu = cpu,
                    GraphicCard = gpu,
                    Motherboard = motherboard,
                    PowerSupply = powerSupply,
                    Ram = ram,
                    CoolersCount = coolersCount
                };
                return assembly;
            }

            else
            {
                throw new Exception(message:"Can't find anything with this price :( ");
            }
        }

        private async Task<GraphicCard> GetGraphicCardAsync(double percent, double price)
        {
            var gpu = await _context.Set<GraphicCard>()
               .Where(c => c.Price <= (price * percent))
               .OrderByDescending(c => c.Price)
               .FirstOrDefaultAsync();
                return gpu;
        }
        private async Task<CPU> GetCpuAsync(double percent, double price, double? remaining)
        {
            var cpu = await _context.Set<CPU>()
                .Where(c => c.Price <= ((price * percent)+remaining))
                .OrderByDescending(c => c.Price)
                .FirstOrDefaultAsync();
            return cpu;
        }

        private async Task<Motherboard> GetMotherboardAsync(double percent, double price, double? remaining, string socket)
        {
            var motherboard = await _context.Set<Motherboard>()
                .Where(c => c.Price <= ((price * percent) + remaining))
                .Where(c => c.Socket.Contains(socket))
                .OrderByDescending(c => c.Price)
                .FirstOrDefaultAsync();
            return motherboard;
        }
        private async Task<Ram> GetRamAsync(double percent, double price, double? remaining, string ramType, int ramSlots)
        {
            var ram = await _context.Set<Ram>()
                    .Where(c => c.Price <= ((price * percent) + remaining))
                    .Where(c => c.Count <= ramSlots)
                    .Where(c => c.RamType.Contains(ramType))
                    .OrderByDescending(c => c.Price)
                    .FirstOrDefaultAsync();
            return ram;
        }
        private async Task<PowerSupply> GetPowerSupplyAsync(double percent, double price, double? remaining, int? power)
        {
            var powerSupply = await _context.Set<PowerSupply>()
                .Where(c => c.Price <= ((price * percent) + remaining))
                .Where(c => c.Power >= power*0.8)
                .OrderByDescending(c => c.Price)
                .FirstOrDefaultAsync();
            return powerSupply;
        }

    }
}
