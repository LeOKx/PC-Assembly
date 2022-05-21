using PcAssembly.Common.Dtos.Component;
using PcAssembly.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PcAssembly.Common.Dtos.CPU
{
    public class AddCpuDto: AddComponentDto
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string? Socket { get; set; }
        [StringLength(40, MinimumLength = 2)]
        [Required]
        public string? Family { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string? Generation { get; set; }
        [Required]
        [Range(1, 256)]
        public int? Cores { get; set; }
        [Required]
        [Range(2, 512)]
        public int? Threads { get; set; }
        [Required]
        [Range(1.0, 10.0)]
        public float? Frequency { get; set; }

    }
}
