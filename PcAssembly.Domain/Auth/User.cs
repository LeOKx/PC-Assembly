using Microsoft.AspNetCore.Identity;
using PcAssembly.Domain.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Domain.Auth
{
    public class User:IdentityUser
    {
        [Required]
        [ConcurrencyCheck]
        [MinLength(8), MaxLength(32)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserProfile? UserProfile { get; set; }
        public ICollection<SavedAssemblies>? SavedAssemblies { get; set; }
    }
}
