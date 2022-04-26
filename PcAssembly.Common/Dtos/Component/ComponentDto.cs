
using PcAssembly.Domain;
using PcAssembly.Domain.Enums;


namespace PcAssembly.Common.Dtos.Component
{
    public class ComponentDto :  BaseEntity
    {
        public string? Model { get; set; }
        public Company? Company { get; set; }
        public TypeComponent? Type { get; set; }
        public double? Price { get; set; }
        public int? PowerConsumption { get; set; } = 100;
    }
}
