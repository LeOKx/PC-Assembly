using PcAssembly.Common.Dtos.ManufacturerInfo;

namespace PcAssembly.Common.Dtos.Component
{
    public class ComponentDto
    {
        public int Id { get; set; }
        public int PowerConsumption { get; set; } = 100;
        public ManufacturerInfoDto ManufacturerInfo { get; set; }
    }
}
