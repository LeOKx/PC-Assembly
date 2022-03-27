using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Domain;
using System.ComponentModel.DataAnnotations;

namespace PcAssembly.Dal.Repositories
{
    //Abstract переделать
    public class ComponentRepository<TComponent> : IComponentRepository<TComponent> where TComponent : Component
    {

        protected readonly DataContext _context;
        //protected DbSet<TComponent> _dbSet;

        public ComponentRepository(DataContext context)
        {
            _context = context;
            //_dbSet = context.Set<TComponent>();
        }

        public async Task<TComponent> AddComponent(TComponent newComponent)
        {
            _context.Set<TComponent>().Add(newComponent);
            await _context.SaveChangesAsync();
            return newComponent;
        }

        public async Task<TComponent> DeleteComponent(int id)
        {
            var component = await GetComponentById(id);
            var info = component.ManufacturerInfo;
            
            //_context.Set<TComponent>().Remove(component);
            _context.ManufacturerInfos.Remove(info);
            await SaveChangesAsync();

            return component;
        }

        public async Task<TComponent> GetComponentById(int id)
        {
            var component = _context.Set<TComponent>().Include(c => c.ManufacturerInfo).FirstAsync(c => c.Id == id);
            if (component == null)
            {
                throw new ValidationException($"Object of type {typeof(TComponent)} with id { id } not found");
            }
            else
            {
                return await component;
            }
 
        }

        public async Task<List<TComponent>> GetComponents()
        {
            return await _context.Set<TComponent>().Include(c => c.ManufacturerInfo).ToListAsync();
        }

        public async Task<TComponent> UpdateComponent(TComponent updatedComponent)
        {
            _context.Set<TComponent>().Update(updatedComponent);
            await SaveChangesAsync();
            return await GetComponentById(updatedComponent.Id);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
