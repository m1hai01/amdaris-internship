using Domain.Models.MedicalCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class File : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime UploadDate { get; set; }

        // Foreign Key
        public Guid MedicalRecordId { get; set; }

        // Navigation Property
        public MedicalRecord MedicalRecord { get; set; } = null!;
    }
}