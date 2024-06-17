using Domain.Models.Diagnosis;

namespace Application.Abstractions
{
    public interface IDiagnosisRepository
    {
        Task<Diagnose> GetByIdAsync(Guid id);

        IQueryable<Diagnose> GetAll();

        Task AddAsync(Diagnose diagnosis);

        Task UpdateAsync(Diagnose diagnosis);

        Task DeleteAsync(Guid id);
    }
}