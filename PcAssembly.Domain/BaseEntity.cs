using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcAssembly.Domain
{
    //Добавить Generic Interface
    public abstract class BaseEntity : IBaseEntity<Guid>
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Id { get; set; }
        [Key]
        public Guid Id { get; set; }
    }
}
