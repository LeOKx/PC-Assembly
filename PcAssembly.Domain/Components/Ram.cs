using PcAssembly.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Domain.Components
{
    public class Ram : Component
    {
        [Required]
        public string? RamType { get; set; }
        [Range(1,256)]
        public int RamSize { get; set; }
        [Range(1,8)]
        public int Count { get; set; }

    }
}
