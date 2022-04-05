using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Domain
{
    public interface IBaseEntity<TId>
    {
        TId Id { get; set; }
    }
}
