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
            IDiagnosisRepository diagnosisRepository,
            ITreatmentRepository treatmentRepository,
            IMedicalCardRepository medicalCardRepository,
            IMedicalRecordRepository medicalRecordRepository,
            IDoctorRepository doctorRepository,
            IPatientRepository patientRepository,
            IDiagnosisFileRepository diagnosisFileRepository
        // Add other repositories as needed
        )
        {
            _dbContext = dbContext;
            UserRepository = userRepository;
            DiagnosisRepository = diagnosisRepository;
            TreatmentRepository = treatmentRepository;
            MedicalCardRepository = medicalCardRepository;
            MedicalRecordRepository = medicalRecordRepository;
            DoctorRepository = doctorRepository;
            PatientRepository = patientRepository;
            DiagnosisFileRepository = diagnosisFileRepository;
            // Initialize other repositories
        }

        public IUserRepository UserRepository { get; }
        public IDiagnosisRepository DiagnosisRepository { get; }
        public ITreatmentRepository TreatmentRepository { get; }
        public IMedicalCardRepository MedicalCardRepository { get; }
        public IMedicalRecordRepository MedicalRecordRepository { get; }
        public IDoctorRepository DoctorRepository { get; }
        public IPatientRepository PatientRepository { get; }
        public IDiagnosisFileRepository DiagnosisFileRepository { get; }

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