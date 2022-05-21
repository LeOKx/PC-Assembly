using PcAssembly.Common.Dtos.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Common.Dtos.GraphicCard
{
    public class GetGraphicCardDto: ComponentDto
    {

        public string? SgRamType { get; set; }

        public int? SgRamSize { get; set; }
    }
}
