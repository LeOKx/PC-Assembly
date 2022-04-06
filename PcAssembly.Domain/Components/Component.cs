using Microsoft.EntityFrameworkCore;
using PcAssembly.Domain.Components;
using PcAssembly.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcAssembly.Domain.Components
{
    public abstract class Component : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        [ConcurrencyCheck]
        public string Model { get; set; }
        [Required]
        public Company Company { get; set; }
        [Required]
        public TypeComponent Type { get; set; }
        [Timestamp]
        public double Price { get; set; } = 0;
        public int PowerConsumption { get; set; } = 100;
        
    }
}
