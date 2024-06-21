using Application.Abstractions;
using Domain.Models.MedicalCard;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class MedicalCardRepository : IMedicalCardRepository
    {
        private readonly MedicalManagementDbContext _context;

        public MedicalCardRepository(MedicalManagementDbContext context)
        {
            _context = context;
        }

        public async Task<MedicalCard> FindByPatientId(Guid patientId)
        {
            return await _context.MedicalCards
                .Include(mc => mc.MedicalRecords)
                .FirstOrDefaultAsync(mc => mc.PatientId == patientId);
        }

        public async Task AddAsync(MedicalCard medicalCard)
        {
            await _context.MedicalCards.AddAsync(medicalCard);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}