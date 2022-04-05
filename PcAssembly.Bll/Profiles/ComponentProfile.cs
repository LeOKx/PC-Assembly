using AutoMapper;
using PcAssembly.Common.Dtos.Component;
using PcAssembly.Domain;
using PcAssembly.Domain.Components;

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
