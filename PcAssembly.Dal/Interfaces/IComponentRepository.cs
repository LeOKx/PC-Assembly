

using PcAssembly.Domain;
using PcAssembly.Domain.Components;

namespace PcAssembly.Dal.Interfaces
{
    public interface IComponentRepository<TComponent> : 
        IGenericRepository<TComponent, Guid> where TComponent : Component, IBaseEntity<Guid>

    {
        public Task<bool> ExistComponentWithTheModel(string model);
        public Task<TComponent> DeleteComponentWithTheModel(string model);
        public Task<List<TComponent>> GetAll(string? searchWord, double? minPrice, double? maxPrice);
    }
}
