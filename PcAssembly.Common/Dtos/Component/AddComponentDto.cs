using PcAssembly.Domain.Enums;

namespace PcAssembly.Common.Dtos.Component
{
    public class AddComponentDto
    {
        public string Model { get; set; } = String.Empty;
        public Company Company { get; set; } = Company.Intel;
        public TypeComponent Type { get; set; } = TypeComponent.CPU;
        public double Price { get; set; } = 0;
        public int PowerConsumption { get; set; } = 100;
    }
}
