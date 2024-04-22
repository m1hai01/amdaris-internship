using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Doctor : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public List<string> JobRoles { get; set; } = null!;
        public List<TimeSpan> AvailableHours { get; set; } = null!;
        public List<Appointment> Appointments { get; set; } = null!;
    }
}