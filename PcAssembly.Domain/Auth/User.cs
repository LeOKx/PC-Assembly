using PcAssembly.Domain.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Domain.Auth
{
    public class User:BaseEntity
    {
        [Required]
        [ConcurrencyCheck]
        [MinLength(8), MaxLength(32)]
        public string? Username { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public UserProfile? UserProfile { get; set; }
        public ICollection<SavedAssemblies>? SavedAssemblies { get; set; }
    }
}
