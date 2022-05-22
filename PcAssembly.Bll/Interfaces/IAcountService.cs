using Microsoft.AspNetCore.Identity;
using PcAssembly.Common.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Bll.Interfaces
{
    public interface IAcountService
    {
        Task<IdentityResult> AddNewUser(UserForRegistrationDto userForRegistration);
    }
}
