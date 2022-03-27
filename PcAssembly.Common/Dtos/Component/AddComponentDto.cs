using PcAssembly.Common.Dtos.ManufacturerInfo;

namespace PcAssembly.Common.Dtos.Component
{
    public class AddComponentDto
    {
        public int PowerConsumption { get; set; } = 100;
        public ManufacturerInfoDto ManufacturerInfo { get; set; }
    }
}
