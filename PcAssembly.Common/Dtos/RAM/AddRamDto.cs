using PcAssembly.Common.Dtos.Component;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Common.Dtos.RAM
{
    public class AddRamDto : AddComponentDto
    {
        [Required]
        public string? RamType { get; set; }
        [Range(1, 256)]
        public int RamSize { get; set; }
        [Range(1, 8)]
        public int Count { get; set; }
    }
}
