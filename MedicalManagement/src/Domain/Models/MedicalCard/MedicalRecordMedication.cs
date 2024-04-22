using Domain.Models.Diagnosis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.MedicalCard
{
    public class MedicalRecordMedication : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Dosage { get; set; } = null!;
        public string Frequency { get; set; } = null!;
        public Guid MedRecTreatId { get; set; } // Foreign Key
        public MedicalRecordTreatment Tratment { get; set; } = null!;
    }
}