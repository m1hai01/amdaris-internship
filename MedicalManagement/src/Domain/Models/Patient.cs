﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Patient : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid MedicalCardId { get; set; }
        public MedicalCard.MedicalCard MedicalCard { get; set; } = null!;
        public List<Appointment> Appointments { get; set; } = null!;
    }
}