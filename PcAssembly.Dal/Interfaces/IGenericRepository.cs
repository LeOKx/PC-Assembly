
using PcAssembly.Common.Models.PagedRequest;
using PcAssembly.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Dal.Interfaces
{
    public interface IGenericRepository<TEntity, TId> where TEntity : class, IBaseEntity<TId>
    {
        Task<TEntity> Insert(TEntity newEntity);
        Task<TEntity> Delete(TEntity deleteEntity);
        Task<TEntity> Delete(TId id);
        Task<List<TEntity>> GetAll();
        Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PagedRequest pagedRequest) where TEntity : BaseEntity
                                                                                     where TDto : class;
        Task<TEntity> GetById(TId id);
        Task<TEntity> Update(TEntity updatedEntity);
        Task SaveChangesAsync();
    }
}
