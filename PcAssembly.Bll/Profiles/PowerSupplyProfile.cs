using AutoMapper;
using PcAssembly.Common.Dtos.CPU;
using PcAssembly.Common.Dtos.PowerSupply;
using PcAssembly.Domain;
using PcAssembly.Domain.Components;

namespace PcAssembly.Bll.Profiles
{
    public class PowerSupplyProfile : Profile
    {
        public PowerSupplyProfile()
        {
            CreateMap<PowerSupply, GetPowerSupplyDto>();
            CreateMap<AddPowerSupplyDto, PowerSupply>();
            CreateMap<UpdatePowerSupplyDto, PowerSupply>();
        }

    }
}
