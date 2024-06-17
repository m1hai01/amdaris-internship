using Application.Abstractions;
using Infrastructure.Data;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MedicalManagementDbContext _dbContext;

        public UnitOfWork(
            MedicalManagementDbContext dbContext,
            IUserRepository userRepository,
            IDiagnosisRepository diagnosisRepository
        // Add other repositories as needed
        )
        {
            _dbContext = dbContext;
            UserRepository = userRepository;
            DiagnosisRepository = diagnosisRepository;
            // Initialize other repositories
        }

        public IUserRepository UserRepository { get; }
        public IDiagnosisRepository DiagnosisRepository { get; }

        // Define other repository properties as needed

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}