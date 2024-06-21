using Application.Abstractions;
using Domain.Models.Diagnosis;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class TreatmentRepository : ITreatmentRepository
    {
        private readonly MedicalManagementDbContext _context;

        public TreatmentRepository(MedicalManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Treatment> GetByIdAsync(Guid id)
        {
            return await _context.Treatments.FindAsync(id);
        }

        public IQueryable<Treatment> GetAll()
        {
            return _context.Treatments.AsQueryable();
        }

        public async Task AddAsync(Treatment treatment)
        {
            await _context.Treatments.AddAsync(treatment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Treatment treatment)
        {
            _context.Treatments.Update(treatment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var treatment = await GetByIdAsync(id);
            if (treatment != null)
            {
                _context.Treatments.Remove(treatment);
                await _context.SaveChangesAsync();
            }
        }
    }
}