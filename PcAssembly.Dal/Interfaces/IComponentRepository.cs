

using PcAssembly.Domain;
using PcAssembly.Domain.Components;

namespace PcAssembly.Dal.Interfaces
{
    public interface IComponentRepository<TComponent> : 
        IGenericRepository<TComponent, Guid> where TComponent : Component, IBaseEntity<Guid>

    {
        public Task<bool> ExistComponentWithTheModel(string model);
    }
}
