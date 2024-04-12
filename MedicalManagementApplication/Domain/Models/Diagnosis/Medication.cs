using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Diagnosis
{
    public class Medication : BaseEntity
    {
        public int Guid { get; set; }
        public string Name { get; set; } = null;
        public string Dosage { get; set; } = null;
        public string Frequency { get; set; } = null;
        public Guid TreatmentId { get; set; } // Foreign Key
        public Treatment Treatment { get; set; }
    }
}