using Microsoft.EntityFrameworkCore;
using PcAssembly.Domain.Components;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcAssembly.Domain.Components
{
    public abstract class Component : BaseEntity /*: ManufacturerInfo*/
    {
        public int PowerConsumption { get; set; } = 100;
        public ManufacturerInfo ManufacturerInfo { get; set; }
        
    }
}
