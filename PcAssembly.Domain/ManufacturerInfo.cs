using Microsoft.EntityFrameworkCore;
using PcAssembly.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PcAssembly.Domain
{
    public class ManufacturerInfo: BaseEntity
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
    }
}
