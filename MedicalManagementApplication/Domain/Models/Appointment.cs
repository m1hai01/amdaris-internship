using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Appointment : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
    }
}