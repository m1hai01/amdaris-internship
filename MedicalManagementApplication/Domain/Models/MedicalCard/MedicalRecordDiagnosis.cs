using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.MedicalCard
{
    public class MedicalRecordDiagnosis : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid MedicalRecordId { get; set; } // Foreign Key
        public MedicalRecord MedicalRecord { get; set; }
        public Guid DiagnosisId { get; set; } // Foreign Key
        public Diagnosis Diagnosis { get; set; }
    }
}