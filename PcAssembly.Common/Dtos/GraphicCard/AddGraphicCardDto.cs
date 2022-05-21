using PcAssembly.Common.Dtos.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Common.Dtos.GraphicCard
{
    public class AddGraphicCardDto:AddComponentDto
    {
        [Required]
        public string? SgRamType { get; set; }
        [Range(1, 64)]
        public int? SgRamSize { get; set; }
    }
}
