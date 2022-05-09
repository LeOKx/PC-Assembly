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

        public async Task<List<TComponent>> GetAll(string? searchWord, double? minPrice, double? maxPrice)
        {
            IQueryable<TComponent> components = DbSet;

            if (!string.IsNullOrWhiteSpace(searchWord))
            {
                //components = components.Where(
                //    e => EF.Functions.Like(e.Model.ToString(), searchWord));
                components = components.Where(e => e.Model.Contains(searchWord));
            }
            if (minPrice.HasValue)
            {
                components = components.Where(e => e.Price >= minPrice);
            }
            if (maxPrice.HasValue)
            {
                components = components.Where(e => e.Price <= maxPrice);
            }

            return await components.ToListAsync();
        }

    }
}
