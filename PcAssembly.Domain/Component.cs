using PcAssembly.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PcAssembly.Domain
{
    public abstract class Component : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Model { get; set; }
        [Required]
        public Company Company { get; set; }
        [Required]
        public TypeComponent Type { get; set; }
        [ConcurrencyCheck]
        public double Price { get; set; } = 0;
        public int PowerConsumption { get; set; } = 100;
        [Required]
    }
}
