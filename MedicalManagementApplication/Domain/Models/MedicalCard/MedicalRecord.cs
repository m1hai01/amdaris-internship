using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.MedicalCard
{
    public class MedicalRecord : BaseEntity
    {
        public string Notes { get; set; } = null;
        public List<MedicalRecordSymptom> Symptoms { get; set; }
        public List<MedicalRecordDiagnosis> Diagnoses { get; set; }
        public List<MedicalRecordTreatment> Treatments { get; set; }
        public List<File> Files { get; set; }
    }
}