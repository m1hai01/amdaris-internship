using Domain.Models;

namespace Application.Abstractions;

public interface IDiagnosisFileRepository
{
    Task<IEnumerable<DiagnosisFile>> GetAllAsync();
    Task<IEnumerable<DiagnosisFile>> GetAllByIdAsync(Guid id);

    Task<DiagnosisFile> GetByIdAsync(int id);

    Task AddAsync(DiagnosisFile diagnosisFile);

    Task UpdateAsync(DiagnosisFile diagnosisFile);

    Task DeleteAsync(int id);
}