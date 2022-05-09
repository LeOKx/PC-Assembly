using Microsoft.EntityFrameworkCore;
using PcAssembly.Domain.Enums;
using System.ComponentModel.DataAnnotations;
namespace PcAssembly.Domain.Components
{
    public class Motherboard : Component
    {  
        [Required]
        [MaxLength(40)]
        public string Socket { get; set; }
        [MaxLength(40)]
        public string Chipset { get; set; }
        [MaxLength(40)]
        public string FormFactor { get; set; }
        [Required]
        [MaxLength(40)]
        public string RamType { get; set; }
        [Required]
        [Range(1,8)]
        public int RamSlots { get; set; }
    }
}
