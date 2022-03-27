

using PcAssembly.Domain;

namespace PcAssembly.Dal.Interfaces
{
    public interface IComponentRepository<TComponent> where TComponent : Component

    {
        Task<TComponent> AddComponent(TComponent newComponent);
        Task<TComponent> DeleteComponent(int id);
        Task<List<TComponent>> GetComponents();
        Task<TComponent> GetComponentById(int id);
        Task<TComponent> UpdateComponent(TComponent updatedComponent);
        Task SaveChangesAsync();
    }
}
