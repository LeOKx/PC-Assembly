using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        public ComponentRepository(DataContext _context) : base(_context)
        {
        }

        public async Task<bool> ExistComponentWithTheModel(string model)
        {
            var component = await _dbSet
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
            var component = await _dbSet
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
