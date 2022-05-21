using Microsoft.EntityFrameworkCore;
using PcAssembly.Domain.Enums;
using System.ComponentModel.DataAnnotations;
namespace PcAssembly.Domain.Components
{
    public class CPU : Component
    {  
        [Required]
        [MaxLength(40)]
        public string? Socket { get; set; }
        [MaxLength(40)]
        public string? Family { get; set; }
        [MaxLength(40)]
        public string? Generation { get; set; }
        [Range(1,256)]
        public int? Cores { get; set; }
        [Range(2, 512)]
        public int? Threads { get; set; }
        [Range(1.0,10.0)]
        public float? Frequency { get; set; }
        //public List<RamType> SupportedRam { get; set; } = new List<RamType>(){ RamType.DDR4 };
    }
}
