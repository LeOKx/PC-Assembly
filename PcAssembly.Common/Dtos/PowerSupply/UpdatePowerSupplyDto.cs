using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcAssembly.Common.Dtos.Component;

namespace PcAssembly.Common.Dtos.PowerSupply
{
    public class UpdatePowerSupplyDto : UpdateComponentDto
    {
        [Required]
        [Range(0, 2000)]
        public int? Power { get; set; }
    }
}
