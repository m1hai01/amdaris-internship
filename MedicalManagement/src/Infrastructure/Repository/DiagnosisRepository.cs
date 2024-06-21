using Application.Abstractions;
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
    public class DiagnosisRepository : IDiagnosisRepository
    {
        private readonly MedicalManagementDbContext _context;

        public DiagnosisRepository(MedicalManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Diagnose> GetByIdAsync(Guid id)
        {
            return await _context
                .Diagnoses
                .Include(d => d.DiagnoseFiles)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public IQueryable<Diagnose> GetAll()
        {
            return _context.Diagnoses.AsQueryable();
        }

        public async Task AddAsync(Diagnose diagnosis)
        {
            await _context.Diagnoses.AddAsync(diagnosis);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Diagnose diagnosis)
        {
            _context.Diagnoses.Update(diagnosis);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var diagnosis = await GetByIdAsync(id);
            if (diagnosis != null)
            {
                _context.Diagnoses.Remove(diagnosis);
                await _context.SaveChangesAsync();
            }
        }
    }
}