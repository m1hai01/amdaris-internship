using Domain.Models.MedicalCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IMedicalRecordRepository
    {
        Task<MedicalRecord> Find(Guid medicalCardId);

        Task AddAsync(MedicalRecord medicalRecord);

        Task SaveChangesAsync();
    }
}