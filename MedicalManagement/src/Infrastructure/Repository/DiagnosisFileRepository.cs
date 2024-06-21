using Application.Abstractions;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class DiagnosisFileRepository : IDiagnosisFileRepository
    {
        private readonly MedicalManagementDbContext _context;

        public DiagnosisFileRepository(MedicalManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DiagnosisFile>> GetAllAsync()
        {
            return await _context.DiagnosisFiles.ToListAsync();
        }

        public async Task<DiagnosisFile> GetByIdAsync(int id)
        {
            return await _context.DiagnosisFiles.FindAsync(id);
        }

        public async Task AddAsync(DiagnosisFile diagnosisFile)
        {
            await _context.DiagnosisFiles.AddAsync(diagnosisFile);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DiagnosisFile diagnosisFile)
        {
            _context.DiagnosisFiles.Update(diagnosisFile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var diagnosisFile = await _context.DiagnosisFiles.FindAsync(id);
            if (diagnosisFile != null)
            {
                _context.DiagnosisFiles.Remove(diagnosisFile);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DiagnosisFile>> GetAllByIdAsync(Guid id)
        {
            return await _context.DiagnosisFiles.Where(d => d.DiagnoseId == id).ToListAsync();
        }
    }
}