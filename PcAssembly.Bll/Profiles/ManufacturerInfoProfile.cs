using AutoMapper;
using PcAssembly.Common.Dtos.ManufacturerInfo;
using PcAssembly.Domain;

namespace PcAssembly.Bll.Profiles
{
    public class ManufacturerInfoProfile : Profile
    {
        public ManufacturerInfoProfile()
        {
            CreateMap<ManufacturerInfo, ManufacturerInfoDto>();
            CreateMap<ManufacturerInfoDto, ManufacturerInfo>();
            CreateMap<UpdateManufacturerInfoDto, ManufacturerInfo>();
        }

    }
}
