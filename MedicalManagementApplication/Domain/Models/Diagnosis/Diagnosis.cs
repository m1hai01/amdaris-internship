using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Diagnosis
{
    public class Diagnosis : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<DiagnosisSymptom> Symptoms { get; set; }
        public List<Treatment> Treatments { get; set; }
    }
}