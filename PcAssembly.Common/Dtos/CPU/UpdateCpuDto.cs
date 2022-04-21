using PcAssembly.Common.Dtos.Component;
using PcAssembly.Domain.Enums;

namespace PcAssembly.Common.Dtos.CPU
{
    public class UpdateCpuDto : UpdateComponentDto
    {
        public Socket? Socket { get; set; }
        public CpuFamily? Family { get; set; }
        public CpuGeneration? Generation { get; set; }
        public int? Cores { get; set; }
        public int? Threads { get; set; }
        public float? Frequency { get; set; }
        //public List<RamType> SupportedRam { get; set; } = new List<RamType>() { RamType.DDR4 };
    }
}
