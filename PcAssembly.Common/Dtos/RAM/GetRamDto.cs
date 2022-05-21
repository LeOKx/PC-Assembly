using PcAssembly.Common.Dtos.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Common.Dtos.RAM
{
    public class GetRamDto : ComponentDto
    {
        public string? RamType { get; set; }
        public int RamSize { get; set; }
        public int Count { get; set; }
    }
}
