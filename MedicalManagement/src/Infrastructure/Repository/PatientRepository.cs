using Application.Abstractions;
using Domain.Models;
using Domain.Models.Diagnosis;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly MedicalManagementDbContext _context;

        public PatientRepository(MedicalManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> GetByIdAsync(Guid id)
        {
            return await _context.Patients.Include(p => p.User)
                                          .Include(p => p.MedicalCard)
                                          .ThenInclude(card => card.MedicalRecords)
                                            .ThenInclude(r => r.Diagnoses)
                                          .FirstOrDefaultAsync(p => p.Id == id);
        }

        public IQueryable<Patient> GetAll()
        {
            return _context.Patients.Include(p => p.User)
                                    .Include(p => p.MedicalCard)
                                    .AsQueryable();
        }

        public async Task AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            //await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var patient = await GetByIdAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Patient> GetByUserId(Guid id)
        {
            return await _context.Patients.Include(p => p.MedicalCard)
                                          .ThenInclude(card => card.MedicalRecords)
                                            .ThenInclude(r => r.Diagnoses)
                                            .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<Patient> GetPatientWithDiagnoses(Guid id)
        {
            return await _context.Patients.Include(p => p.MedicalCard)
                                              .ThenInclude(card => card.MedicalRecords)
                                              .ThenInclude(r => r.Diagnoses)
                                              .ThenInclude(r => r.Diagnose)
                                                .ThenInclude(d => d.DiagnoseFiles)
                                              .FirstOrDefaultAsync(p => p.UserId == id);
        }
    }
}