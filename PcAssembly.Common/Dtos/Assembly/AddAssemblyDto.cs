using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Common.Dtos.Assembly
{
    public class AddAssemblyDto
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        [Required]
        public Guid Cpu { get; set; }
        [Required]
        public Guid GraphicCard { get; set; }
        [Required]
        public Guid Motherboard { get; set; }
        [Required]
        public Guid Ram { get; set; }
        [Required]
        public Guid PowerSupply { get; set; }
        public int CoolersCount { get; set; }
        [Required]
        public string UserId { get; set; }
        public double TotalPrice { get; set; }
        public int Rating { get; set; }
        public string? ImageUrl { get; set; }

    }
}
