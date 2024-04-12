using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.MedicalCard
{
    public class Consume
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public ConsumeStatus Status { get; set; }

        // Foreign Key
        public Guid MedicalRecordTreatmentId { get; set; }

        // Navigation Property
        public MedicalRecordTreatment MedicalRecordTreatment { get; set; }
    }
}