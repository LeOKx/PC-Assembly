

using PcAssembly.Domain;
using PcAssembly.Domain.Components;

namespace PcAssembly.Dal.Interfaces
{
    public interface ICpuRepository: IComponentRepository<CPU, int>
    {
        Task<bool> ExistCpuWithTheModel(string model);
    }
}
