using PcAssembly.Common.Dtos.ManufacturerInfo;

namespace PcAssembly.Common.Dtos.Component
{
    public class UpdateComponentDto
    {
        public int PowerConsumption { get; set; } = 100;
        public UpdateManufacturerInfoDto ManufacturerInfo { get; set; }
    }
}
