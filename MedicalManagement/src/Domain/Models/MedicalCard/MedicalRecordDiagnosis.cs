using Domain.Models.Diagnosis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.MedicalCard
{
    public class MedicalRecordDiagnosis : BaseEntity
    {
        public Guid MedicalRecordId { get; set; } // Foreign Key
        public MedicalRecord MedicalRecord { get; set; } = null!;
        public Guid DiagnosisId { get; set; } // Foreign Key
        public Diagnose Diagnose { get; set; } = null!;
    }
}