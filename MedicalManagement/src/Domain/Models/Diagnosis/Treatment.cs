using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Diagnosis
{
    //diagnosis
    public class Treatment : BaseEntity
    {
        public string Name { get; set; } = null!;
        public Guid DiagnosisId { get; set; } // Foreign Key
        public Diagnose Diagnose { get; set; } = null!;
        public List<Medication> Medications { get; set; } = null!;
        public int Duration { get; set; } // Number of days/weeks/months
        public DurationUnit DurationUnit { get; set; } // Unit of duration (days/weeks/months)
    }
}