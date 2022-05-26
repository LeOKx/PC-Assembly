using Microsoft.EntityFrameworkCore;
using PcAssembly.Domain.Components;
using PcAssembly.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcAssembly.Domain.Components
{
    public class Component : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string? Model { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Company { get; set; }
        [Required]
        public TypeComponent? Type { get; set; }
        [ConcurrencyCheck]
        public double? Price { get; set; }
        [Range(1,3000)]
        public int? PowerConsumption { get; set; }
        [Url]
        public string? ImageUrl { get; set; }
        public string? InfoAbout { get; set; }

    }
}
