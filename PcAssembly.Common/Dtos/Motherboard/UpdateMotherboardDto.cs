using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcAssembly.Common.Dtos.Component;

namespace PcAssembly.Common.Dtos.Motherboard
{
    public class UpdateMotherboardDto : UpdateComponentDto
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Socket { get; set; }
        [StringLength(40, MinimumLength = 2)]
        public string Chipset { get; set; }
        [StringLength(40, MinimumLength = 2)]
        public string FormFactor { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string RamType { get; set; }
        [Required]
        [Range(1, 8)]
        public int RamSlots { get; set; }
    }
}
