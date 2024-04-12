using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Diagnosis
{
    public class DiagnosisSymptom : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid DiagnosisId { get; set; } // Foreign Key
        public Diagnosis Diagnosis { get; set; }
        public Guid SymptomId { get; set; } // Foreign Key
        public Symptom Symptom { get; set; }
    }
}