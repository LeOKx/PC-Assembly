using AutoMapper;
using PcAssembly.Common.Dtos.CPU;
using PcAssembly.Common.Dtos.Motherboard;
using PcAssembly.Domain;
using PcAssembly.Domain.Components;

namespace PcAssembly.Bll.Profiles
{
    public class MotherboardProfile : Profile
    {
        public MotherboardProfile()
        {
            CreateMap<Motherboard, GetMotherboardDto>();
            CreateMap<AddMotherboardDto, Motherboard>();
            CreateMap<UpdateMotherboardDto, Motherboard>();
        }

    }
}
