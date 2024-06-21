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
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly MedicalManagementDbContext _context;

        public MedicalRecordRepository(MedicalManagementDbContext context)
        {
            _context = context;
        }

        public async Task<MedicalRecord> Find(Guid medicalCardId)
        {
            return await _context.MedicalRecords
                .Include(mr => mr.Diagnoses)
                .FirstOrDefaultAsync(mr => mr.MedicalCardId == medicalCardId);
        }

        public async Task AddAsync(MedicalRecord medicalRecord)
        {
            await _context.MedicalRecords.AddAsync(medicalRecord);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}