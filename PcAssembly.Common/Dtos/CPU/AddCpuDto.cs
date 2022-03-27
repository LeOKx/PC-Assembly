using PcAssembly.Common.Dtos.Component;
using PcAssembly.Domain.Enums;

namespace PcAssembly.Common.Dtos.CPU
{
    public class AddCpuDto: AddComponentDto
    {
        public Socket Socket { get; set; } = Socket.Socket_1700;
        public CpuFamily Family { get; set; } = CpuFamily.Core_i9;
        public CpuGeneration Generation { get; set; } = CpuGeneration.AlderLake;
        public int Cores { get; set; } = 0;
        public int Threads { get; set; } = 0;
        public float Frequency { get; set; } = 0;
        //public List<RamType> SupportedRam { get; set; } = new List<RamType>() { RamType.DDR4 };

    }
}
