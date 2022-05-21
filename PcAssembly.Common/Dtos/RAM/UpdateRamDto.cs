using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcAssembly.Common.Dtos.Component;

namespace PcAssembly.Common.Dtos.RAM
{
    public class UpdateRamDto : UpdateComponentDto
    {
        [Required]
        public string? RamType { get; set; }
        [Range(1, 256)]
        public int RamSize { get; set; }
        [Range(1, 8)]
        public int Count { get; set; }
    }
}
