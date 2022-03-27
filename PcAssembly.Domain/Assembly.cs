using System.ComponentModel.DataAnnotations;

namespace PcAssembly.Domain
{
    public class Assembly : BaseEntity
    {
        [Required]
        public string Name { get; set; } = "New Assembly";
        public CPU Cpu { get; set; }
        [ConcurrencyCheck]
        public double TotalPrice { get; set; } = 0;

        //public override bool Equals(object? obj)
        //{
        //    if (obj is Assembly assembly) return Id == assembly.Id;
        //    return false;
        //}
    }
}
