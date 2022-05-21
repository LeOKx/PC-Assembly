
using PcAssembly.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PcAssembly.Common.Dtos.Component
{
    public class UpdateComponentDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Model { get; set; }
        [Required]
        [StringLength( 50, MinimumLength = 3)]
        public string? Company { get; set; }
        [Required]
        public TypeComponent? Type { get; set; }
        [Required]
        [ConcurrencyCheck]
        public double? Price { get; set; }
        [Required]
        [Range(1, 3000)]
        public int? PowerConsumption { get; set; }
        [Url]
        public string? ImageUrl { get; set; }
        [StringLength(500)]
        public string? InfoAbout { get; set; }
    }
}
