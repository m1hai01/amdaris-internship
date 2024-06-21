using Application.Abstractions;
using Application.Commands.Treatment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Treatment
{
    public class UpdateTreatmentCommandHandler : IRequestHandler<UpdateTreatmentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTreatmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateTreatmentCommand request, CancellationToken cancellationToken)
        {
            var treatment = await _unitOfWork.TreatmentRepository.GetByIdAsync(request.Id);

            if (treatment == null)
            {
                throw new ArgumentException("Treatment not found");
            }

            treatment.Name = request.Name;
            treatment.DiagnosisId = request.DiagnosisId;
            treatment.Duration = request.Duration;
            treatment.DurationUnit = request.DurationUnit;

            await _unitOfWork.TreatmentRepository.UpdateAsync(treatment);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}