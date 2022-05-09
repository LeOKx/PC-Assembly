using PcAssembly.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Domain.Components
{
    public class PowerSupply : Component
    {
        [Required]
        [Range(0,2000)]
        public int? Power { get; set; }
    }
}
