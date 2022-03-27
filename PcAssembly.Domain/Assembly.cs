using System.ComponentModel.DataAnnotations;

namespace PcAssembly.Domain
{
    public class Assembly : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public int cpuId { get; set; }
        public CPU Cpu { get; set; }
        [ConcurrencyCheck]
        public double TotalPrice { get; set; }

        //public override bool Equals(object? obj)
        //{
        //    if (obj is Assembly assembly) return Id == assembly.Id;
        //    return false;
        //}
    }
}
