using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcAssembly.Domain
{
    public abstract class Component : BaseEntity
    {
        public int PowerConsumption { get; set; } = 100;
        [ForeignKey(nameof(ManufacturerInfoId))]
        public int ManufacturerInfoId { get; set; }
        public ManufacturerInfo ManufacturerInfo { get; set; }
        
    }
}
