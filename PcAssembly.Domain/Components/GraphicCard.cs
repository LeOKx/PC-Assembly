using PcAssembly.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Domain.Components
{
    public class GraphicCard : Component
    {
        [Required]
        public SgRamType SgRamType { get; set; }
        public int SgRamSize { get; set; }
        [MaxLength(250)]
        public string About { get; set; }
    }
}
