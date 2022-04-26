using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Dal.Test
{
    public class DataContextMock : DataContext
    {
        public DataContextMock(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

       
    }
}
