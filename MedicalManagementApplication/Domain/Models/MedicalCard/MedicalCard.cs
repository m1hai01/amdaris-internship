using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.MedicalCard
{
    public class MedicalCard : BaseEntity
    {
        public Patient Patient { get; set; }
        public List<MedicalRecord> MedicalRecords { get; set; } = new();
        public string? State { get; set; }
    }
}