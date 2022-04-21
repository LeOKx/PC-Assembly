using Microsoft.EntityFrameworkCore;
using PcAssembly.Domain.Enums;
using System.ComponentModel.DataAnnotations;
namespace PcAssembly.Domain.Components
{
    public class CPU:Component
    {  
        [Required]
        public Socket? Socket { get; set; }
        public CpuFamily? Family { get; set; }
        public CpuGeneration? Generation { get; set; }
        public int? Cores { get; set; }
        public int? Threads { get; set; }
        public float? Frequency { get; set; }
        //public List<RamType> SupportedRam { get; set; } = new List<RamType>(){ RamType.DDR4 };
    }
}
