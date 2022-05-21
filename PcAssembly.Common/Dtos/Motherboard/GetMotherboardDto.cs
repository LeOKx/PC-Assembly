using PcAssembly.Common.Dtos.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Common.Dtos.Motherboard
{
    public class GetMotherboardDto : ComponentDto
    {
        public string Socket { get; set; }
        public string Chipset { get; set; }
        public string FormFactor { get; set; }
        public string RamType { get; set; }
        public int RamSlots { get; set; }
    }
}
