using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PcAssembly.Common.Models;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Domain;
using PcAssembly.Domain.Components;
using System.ComponentModel.DataAnnotations;

namespace PcAssembly.Dal.Repositories
{
    //Abstract переделать
    public class ComponentRepository<TComponent> : GenericRepository<TComponent, Guid>, 
        IComponentRepository<TComponent> where TComponent : Component, IBaseEntity<Guid>
    {
        public ComponentRepository(DataContext _context, IMapper _mapper) : base(_context, _mapper)
        {
        }

        public async Task<bool> ExistComponentWithTheModel(string model) 
        {
            var component = await DbSet
                .FirstOrDefaultAsync(c => c.Model == model);
            if (component == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task<TComponent> DeleteComponentWithTheModel(string model)
        {
            var component = await DbSet
                .FirstOrDefaultAsync(c => c.Model == model);

            if (component != null)
            {
                await Delete(component);
                return component;
            }
            else
            {
                throw new Exception("Haven't component with this model in Data Base");
            }
        }

    }
}
