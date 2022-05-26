using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcAssembly.Domain
{
        public abstract class BaseEntity : IBaseEntity<Guid>
    {
                        [Key]
        public Guid Id { get; set; }
    }
}
