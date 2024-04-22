using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.MedicalCard
{
    public class MedicalRecord : BaseEntity
    {
        public Guid MedicalCardId { get; set; }
        public MedicalCard MedicalCard { get; set; } = null!;
        public string Notes { get; set; } = null!;
        public List<MedicalRecordSymptom> Symptoms { get; set; } = null!;
        public List<MedicalRecordDiagnosis> Diagnoses { get; set; } = null!;
        public MedicalRecordTreatment Treatment { get; set; } = null!;
        public List<File> Files { get; set; } = null!;
    }
}