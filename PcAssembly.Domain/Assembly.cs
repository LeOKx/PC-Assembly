using PcAssembly.Domain.Auth;
using PcAssembly.Domain.Components;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcAssembly.Domain
{
    public class Assembly : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        public Guid CpuId { get; set; }
        public CPU? Cpu { get; set; }
        public Guid GraphicCardId { get; set; }
        public GraphicCard? GraphicCard { get; set; }
        [Required]
        public User? User { get; set; }

        public double TotalPrice { get; set; }
        [Column(TypeName = "Date")]
        public DateTime CreateDate { get; set; }
        public ICollection<SavedAssemblies>? SavedAssemblies { get; set; }
    }
}
