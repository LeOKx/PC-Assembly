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
            CreateMap<AddAssemblyDto, Assembly>();
        }
        
    }
}
