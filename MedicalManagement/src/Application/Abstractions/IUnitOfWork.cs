namespace Application.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IDiagnosisRepository DiagnosisRepository { get; }
        ITreatmentRepository TreatmentRepository { get; }
        IMedicalCardRepository MedicalCardRepository { get; }
        IMedicalRecordRepository MedicalRecordRepository { get; }
        IDoctorRepository DoctorRepository { get; }
        IPatientRepository PatientRepository { get; }
        IDiagnosisFileRepository DiagnosisFileRepository { get; }
        //other repository properties

        Task<int> CommitAsync();
    }
}