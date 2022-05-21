using AutoMapper;
using PcAssembly.Common.Dtos.User;
using PcAssembly.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Bll.Profiles
{
    public class UserIdentityProfile:Profile
    {
        public UserIdentityProfile()
        {
            CreateMap<UserForRegistrationDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
