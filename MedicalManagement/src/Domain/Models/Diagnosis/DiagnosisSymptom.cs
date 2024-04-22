using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Diagnosis
{
    public class DiagnosisSymptom : BaseEntity
    {
        public Guid DiagnosisId { get; set; } // Foreign Key
        public Diagnose Diagnose { get; set; } = null!;
        public Guid SymptomId { get; set; } // Foreign Key
        public Symptom Symptom { get; set; } = null!;
    }
}