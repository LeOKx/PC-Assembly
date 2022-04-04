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

        //protected readonly DataContext _context;
        ////protected DbSet<TComponent> _dbSet;

        //public ComponentRepository(DataContext context)
        //{
        //    _context = context;
        //    //_dbSet = context.Set<TComponent>();
        //}

        //public async Task<TComponent> Insert(TComponent newComponent)
        //{

        //    _context.Set<TComponent>().Add(newComponent);
        //    await _context.SaveChangesAsync();
        //    return newComponent;
        //}

        public async Task<TComponent> DeleteComponent(TComponent deleteComponent)
        {
            try
            {
                var info = deleteComponent.ManufacturerInfo;
                _context.ManufacturerInfos.Remove(info);
                await SaveChangesAsync();

                return deleteComponent;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<TComponent> DeleteComponent(TId id)
        {

            var component = await GetComponentById(id);
            var info = component.ManufacturerInfo;
            _context.ManufacturerInfos.Remove(info);
            await SaveChangesAsync();

            return component;
        }

        public async Task<TComponent> GetComponentById(TId id)
        {
            var component = _dbSet.Include(c => c.ManufacturerInfo).FirstAsync(c => c.Id.Equals(id));
            if (component == null)
            {
                throw new Exception($"Object of type {typeof(TComponent)} with id { id } not found");
            }
            else
            {
                return await component;
            }
 
        }

        public async Task<List<TComponent>> GetComponents()
        {
           return await _dbSet.Include(c => c.ManufacturerInfo).ToListAsync();
        }

        //public async Task<TComponent> Update(TComponent updatedComponent)
        //{
        //    _context.Set<TComponent>().Update(updatedComponent);
        //    await SaveChangesAsync();
        //    return await GetComponentById(updatedComponent.Id);
        //}
    }
}
