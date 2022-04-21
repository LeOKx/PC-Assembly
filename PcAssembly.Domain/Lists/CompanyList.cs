﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Domain.Lists
{
    public class CompanyList
    {
        [Key]
        [Required]
        public string? CompanyName { get; set; }
    }
}
