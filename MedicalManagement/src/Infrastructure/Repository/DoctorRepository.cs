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
    public class DoctorRepository : IDoctorRepository
    {
        private readonly MedicalManagementDbContext _context;

        public DoctorRepository(MedicalManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Doctor> GetByIdAsync(Guid id)
        {
            return await _context.Doctors.Include(d => d.User).FirstOrDefaultAsync(d => d.Id == id);
        }

        public IQueryable<Doctor> GetAll()
        {
            return _context.Doctors.Include(d => d.User).AsQueryable();
        }

        public async Task AddAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var doctor = await GetByIdAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
    }
}