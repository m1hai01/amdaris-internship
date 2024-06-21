using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Diagnosis
{
    public class Diagnose : BaseEntity
    {
        public string Name { get; set; } = null!;
        public virtual List<DiagnosisSymptom?> Symptoms { get; set; } = new();
        public virtual Treatment? Treatment { get; set; } = new();
        public List<DiagnosisFile> DiagnoseFiles { get; set; } = new List<DiagnosisFile>();
    }
}