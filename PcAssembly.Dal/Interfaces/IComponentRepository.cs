

using PcAssembly.Domain;
using PcAssembly.Domain.Components;

namespace PcAssembly.Dal.Interfaces
{
    public interface IComponentRepository<TComponent, TId> : 
        IGenericRepository<TComponent, TId> where TComponent : Component, IBaseEntity<TId>

    {
        //Task<TComponent> Insert(TComponent newComponent);
        Task<TComponent> DeleteComponent(TComponent deleteComponent);
        Task<TComponent> DeleteComponent(TId id);
        Task<List<TComponent>> GetComponents();
        Task<TComponent> GetComponentById(TId id);
        //Task<TComponent> Update(TComponent updatedComponent);
    }
}
