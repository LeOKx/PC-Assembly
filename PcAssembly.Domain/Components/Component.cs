using Microsoft.EntityFrameworkCore;
using PcAssembly.Domain.Components;
using PcAssembly.Domain.Enums;
//using PcAssembly.Domain.Lists;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcAssembly.Domain.Components
{
    public class Component : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string? Model { get; set; }
        [Required]
        public Company? Company { get; set; }
        //[ForeignKey(nameof(Company))]
        //public string CompanyId { get; set; }
        //public CompanyList? Company { get; set; }
        [Required]
        public TypeComponent? Type { get; set; }
        [ConcurrencyCheck]
        public double? Price { get; set; }
        public int? PowerConsumption { get; set; }
        
    }
}
