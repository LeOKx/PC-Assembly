using AutoMapper;
using PcAssembly.Common.Dtos.CPU;
using PcAssembly.Common.Dtos.RAM;
using PcAssembly.Domain;
using PcAssembly.Domain.Components;

namespace PcAssembly.Bll.Profiles
{
    public class RamProfile : Profile
    {
        public RamProfile()
        {
            CreateMap<Ram, GetRamDto>();
            CreateMap<AddRamDto, Ram>();
            CreateMap<UpdateRamDto, Ram>();
        }

    }
}
