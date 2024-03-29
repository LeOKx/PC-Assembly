﻿using AutoMapper;
using PcAssembly.Common.Dtos.CPU;
using PcAssembly.Domain;
using PcAssembly.Domain.Components;

namespace PcAssembly.Bll.Profiles
{
    public class CpuProfile : Profile
    {
        public CpuProfile()
        {
            CreateMap<CPU, GetCpuDto>();
            CreateMap<AddCpuDto, CPU>();
            CreateMap<UpdateCpuDto, CPU>();
        }

    }
}
