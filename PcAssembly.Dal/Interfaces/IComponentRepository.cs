

using PcAssembly.Domain;
using PcAssembly.Domain.Components;

namespace PcAssembly.Dal.Interfaces
{
    public interface IComponentRepository<TComponent, TId> : 
        IGenericRepository<TComponent, TId> where TComponent : Component, IBaseEntity<TId>

    {
        public Task<bool> ExistComponentWithTheModel(string model);
    }
}
