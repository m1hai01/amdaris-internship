﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Symptom : BaseEntity
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}