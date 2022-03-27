using System.ComponentModel.DataAnnotations;

namespace PcAssembly.Domain
{
    public abstract class Component : BaseEntity
    {
        public int PowerConsumption { get; set; } = 100;
        [Required]
        public ManufacturerInfo ManufacturerInfo { get; set; }
    }
}
