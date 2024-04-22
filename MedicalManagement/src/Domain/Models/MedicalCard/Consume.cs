using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.MedicalCard
{
    public class Consume : BaseEntity
    {
        public DateTime DateTime { get; set; }
        public ConsumeStatus Status { get; set; }

        // Foreign Key
        public Guid MedicalRecordMedicationId { get; set; }

        // Navigation Property
        public MedicalRecordMedication MedicalRecordMedication { get; set; } = null!;
    }
}