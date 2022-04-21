﻿using PcAssembly.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Domain
{
    public class SavedAssemblies:BaseEntity
    {
        //public int AssemblyId { get; set; }
        public Assembly? Assembly { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
