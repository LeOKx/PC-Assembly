

using PcAssembly.Domain;

namespace PcAssembly.Dal.Interfaces
{
    public interface ICpuRepository: IComponentRepository<CPU>
    {
        Task<bool> ExistCpuWithTheModel(string model);
    }
}
