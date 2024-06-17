namespace Application.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IDiagnosisRepository DiagnosisRepository { get; }

        //other repository properties

        Task<int> CommitAsync();
    }
}