using Domain.Models.MedicalCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IMedicalCardRepository
    {
        Task<MedicalCard> FindByPatientId(Guid patientId);

        Task AddAsync(MedicalCard medicalCard);

        Task SaveChangesAsync();
    }
}