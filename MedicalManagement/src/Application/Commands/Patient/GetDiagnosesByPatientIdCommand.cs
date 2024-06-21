using MediatR;

namespace Application.Commands.Patient
{
    public class GetDiagnosesByPatientIdCommand : IRequest<Domain.Models.Patient>
    {
        public Guid PatientId { get; init; }

        public GetDiagnosesByPatientIdCommand(Guid userId)
        {
            PatientId = userId;
        }
    }
}