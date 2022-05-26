using PcAssembly.Domain.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Domain
{
    public class RatedByUserAssembly
    {
                [Key]
        [ForeignKey(nameof(Assembly))]
        public Guid AssemblyId { get; set; }
        public Assembly? Assembly { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User? User { get; set; }
    }
}
