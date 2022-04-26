using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Bll.Filters
{
    public class SearchOptions
    {
        public string? SearchWord { get; set; }
        //public string? SearchType { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }

    }
}
