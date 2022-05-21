using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Domain
{
    public class Image :BaseEntity
    {
        public byte[] Data { get; set; }
    }
}
