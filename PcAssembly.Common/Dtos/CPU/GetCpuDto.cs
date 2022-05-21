using PcAssembly.Common.Dtos.Component;
using PcAssembly.Domain.Enums;

namespace PcAssembly.Common.Dtos.CPU
{
    public class GetCpuDto: ComponentDto
    {
        public string? Socket { get; set; }
        public string? Family { get; set; }
        public string? Generation { get; set; }
        public int? Cores { get; set; } 
        public int? Threads { get; set; }
        public float? Frequency { get; set; }
    }
}
