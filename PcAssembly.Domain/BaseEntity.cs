using System.ComponentModel.DataAnnotations;
namespace PcAssembly.Domain
{
    //Добавить Generic Interface
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
