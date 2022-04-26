using Microsoft.EntityFrameworkCore;
using PcAssembly.Dal.Interfaces;
using PcAssembly.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Dal.Repositories
{
    public class GenericRepository<TEntity, TId> : 
        IGenericRepository<TEntity, TId> where TEntity : class, IBaseEntity<TId>
    {
        protected readonly DataContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        //public GenericRepository()
        //{
        //    this._context = new DataContext();
        //    table = _context.Set<TEntity>();
        //}
        public GenericRepository(DataContext _context)
        {
            this._context = _context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> GetById(TId id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> Insert(TEntity newEntity)
        {
            try
            {
                newEntity.Id = newEntity.Id == null ? Guid.NewGuid() : newEntity.Id;
                _dbSet.Add(newEntity);
                await _context.SaveChangesAsync(); 
                return newEntity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<TEntity> Update(TEntity updatedEntity)
        {
            try
            {
                _dbSet.Update(updatedEntity);
                await _context.SaveChangesAsync();
                return updatedEntity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<TEntity> Delete(TEntity deleteEntity)
        {
            try
            {
                _dbSet.Remove(deleteEntity);
                await _context.SaveChangesAsync();
                return deleteEntity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<TEntity> Delete(TId id)
        {
            try
            {
                TEntity existing = await _dbSet.FindAsync(id);
                _dbSet.Remove(existing);
                await _context.SaveChangesAsync();
                return existing;
            }
            catch (Exception ex) 
            { 
                throw; 
            }
            
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
