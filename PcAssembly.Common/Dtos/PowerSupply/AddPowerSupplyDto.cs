using PcAssembly.Common.Dtos.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Common.Dtos.PowerSupply
{
    public class AddPowerSupplyDto : AddComponentDto
    {
        [Required]
        [Range(0, 2000)]
        public int? Power { get; set; }
    }
}
