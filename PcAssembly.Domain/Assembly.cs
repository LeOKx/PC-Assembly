using PcAssembly.Domain.Auth;
using PcAssembly.Domain.Components;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcAssembly.Domain
{
    public class Assembly : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        public Guid CpuId { get; set; }
        public CPU? Cpu { get; set; }
        [Required]
        public Guid GraphicCardId { get; set; }
        public GraphicCard? GraphicCard { get; set; }
        [Required]
        public Guid MotherboardId { get; set; }
        public Motherboard? Motherboard { get; set; }
        [Required]
        public Guid RamId { get; set; }
        public Ram? Ram { get; set; }
        [Required]
        public Guid PowerSupplyId { get; set; }
        public PowerSupply? PowerSupply { get; set; }
        public int? CoolersCount { get; set; }
        [Required]
        public string? UserId { get; set; }
        public User? User { get; set; }
        public double TotalPrice { get; set; }
        public int Rating { get; set; }
        [Url]
        public string? ImageUrl { get; set; }
        [Column(TypeName = "Date")]
        public DateTime CreateDate { get; set; }
        public ICollection<SavedAssemblies>? SavedAssemblies { get; set; }
    }
}
