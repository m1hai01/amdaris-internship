using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Patient : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int MedicalCardId { get; set; }
        public MedicalCard.MedicalCard MedicalCard { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}