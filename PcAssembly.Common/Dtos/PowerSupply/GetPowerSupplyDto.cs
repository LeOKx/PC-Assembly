
using PcAssembly.Common.Dtos.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Common.Dtos.PowerSupply
{
    public class GetPowerSupplyDto : ComponentDto
    {
        public int? Power { get; set; }
    }
}
