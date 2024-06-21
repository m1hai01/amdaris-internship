using Domain.Models.Diagnosis;

namespace Application.Abstractions
{
    public interface ITreatmentRepository
    {
        Task<Treatment> GetByIdAsync(Guid id);

        IQueryable<Treatment> GetAll();

        Task AddAsync(Treatment treatment);

        Task UpdateAsync(Treatment treatment);

        Task DeleteAsync(Guid id);
    }
}