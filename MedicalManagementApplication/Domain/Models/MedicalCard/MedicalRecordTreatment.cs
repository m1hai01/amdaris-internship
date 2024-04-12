using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.MedicalCard
{
    public class MedicalRecordTreatment : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null;
        public List<MedicalRecordMedication> Medications { get; set; }
        public int Duration { get; set; } // Number of days/weeks/months
        public DurationUnit DurationUnit { get; set; } // Unit of duration (days/weeks/months)

        // Foreign Key
        public Guid MedicalRecordId { get; set; }

        // Navigation Property
        public MedicalRecord MedicalRecord { get; set; }
    }
}