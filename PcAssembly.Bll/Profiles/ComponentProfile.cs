using AutoMapper;
using PcAssembly.Common.Dtos.Component;
using PcAssembly.Domain;

namespace PcAssembly.Bll.Profiles
{
    public class ComponentProfile : Profile
    {
        public ComponentProfile()
        {
            CreateMap<Component, ComponentDto>();
            CreateMap<AddComponentDto, Component>();
            CreateMap<UpdateComponentDto, Component>();
        }

    }
}
