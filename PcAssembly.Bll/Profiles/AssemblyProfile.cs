using AutoMapper;
using PcAssembly.Common.Dtos.Assembly;
using PcAssembly.Domain;


namespace PcAssembly.Bll.Profiles
{
    public class AssemblyProfile : Profile
    {
        public AssemblyProfile()
        {
            CreateMap<Assembly, GetAssemblyDto>();
            CreateMap<Assembly, GenerateAssemblyDto>();
            CreateMap<AddAssemblyDto, Assembly>()
                .ForMember(a => a.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(a => a.GraphicCardId, opt => opt.MapFrom(x => x.GraphicCard))
                .ForMember(a => a.CpuId, opt => opt.MapFrom(x => x.Cpu))
                .ForMember(a => a.MotherboardId, opt => opt.MapFrom(x => x.Motherboard))
                .ForMember(a => a.RamId, opt => opt.MapFrom(x => x.Ram))
                .ForMember(a => a.PowerSupplyId, opt => opt.MapFrom(x => x.PowerSupply))
                .ForMember(a => a.Cpu, opt => opt.Ignore())
                .ForMember(a => a.GraphicCard, opt => opt.Ignore())
                .ForMember(a => a.Motherboard, opt => opt.Ignore())
                .ForMember(a => a.Ram, opt => opt.Ignore())
                .ForMember(a => a.PowerSupply, opt => opt.Ignore())
                .ForMember(a => a.User, opt => opt.Ignore());

            CreateMap<UpdateAssemblyDto, Assembly>()
                .ForMember(a => a.GraphicCardId, opt => opt.MapFrom(x => x.GraphicCard))
                .ForMember(a => a.CpuId, opt => opt.MapFrom(x => x.Cpu))
                .ForMember(a => a.MotherboardId, opt => opt.MapFrom(x => x.Motherboard))
                .ForMember(a => a.RamId, opt => opt.MapFrom(x => x.Ram))
                .ForMember(a => a.PowerSupplyId, opt => opt.MapFrom(x => x.PowerSupply))
                .ForMember(a => a.Cpu, opt => opt.Ignore())
                .ForMember(a => a.GraphicCard, opt => opt.Ignore())
                .ForMember(a => a.Motherboard, opt => opt.Ignore())
                .ForMember(a => a.Ram, opt => opt.Ignore())
                .ForMember(a => a.PowerSupply, opt => opt.Ignore());
        }

    }
}
