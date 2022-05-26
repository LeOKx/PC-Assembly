using PcAssembly.Common.Dtos.CPU;
using PcAssembly.Common.Dtos.GraphicCard;
using PcAssembly.Common.Dtos.Motherboard;
using PcAssembly.Common.Dtos.PowerSupply;
using PcAssembly.Common.Dtos.RAM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcAssembly.Domain.Components;
using PcAssembly.Domain;

namespace PcAssembly.Common.Dtos.Assembly
{
    public class GenerateAssemblyDto
    {
        public GetCpuDto Cpu { get; set; }
        public GetGraphicCardDto GraphicCard { get; set; }
        public GetMotherboardDto Motherboard { get; set; }
        public GetRamDto Ram { get; set; }
        public GetPowerSupplyDto PowerSupply { get; set; }
        public int CoolersCount { get; set; }
    }
}
