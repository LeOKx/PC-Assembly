using AutoMapper;
using PcAssembly.Common.Dtos.ManufacturerInfo;
using PcAssembly.Domain;
using PcAssembly.Domain.Components;

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
