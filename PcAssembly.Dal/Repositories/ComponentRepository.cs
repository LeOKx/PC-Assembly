using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Domain;
using PcAssembly.Domain.Components;
using System.ComponentModel.DataAnnotations;

namespace PcAssembly.Dal.Repositories
{
    //Abstract переделать
    public class ComponentRepository<TComponent, TId> : GenericRepository<TComponent, TId>, 
        IComponentRepository<TComponent, TId> where TComponent : Component, IBaseEntity<TId>
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

    }
}
