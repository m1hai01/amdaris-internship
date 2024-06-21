using Application.Abstractions;
using Application.Commands.Treatment;
using MediatR;

namespace Application.CommandHandlers.Treatment
{
    public class CreateTreatmentCommandHandler : IRequestHandler<CreateTreatmentCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTreatmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateTreatmentCommand request, CancellationToken cancellationToken)
        {
            var treatment = new Domain.Models.Diagnosis.Treatment
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                DiagnosisId = request.DiagnosisId,
                Duration = request.Duration,
                DurationUnit = request.DurationUnit
            };

            await _unitOfWork.TreatmentRepository.AddAsync(treatment);
            await _unitOfWork.CommitAsync();

            return treatment.Id;
        }
    }
}