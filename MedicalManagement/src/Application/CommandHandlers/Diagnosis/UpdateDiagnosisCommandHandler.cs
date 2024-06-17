using Application.Abstractions;
using Application.Commands.Diagnosis;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Diagnosis
{
    public class UpdateDiagnosisCommandHandler : IRequestHandler<UpdateDiagnosisCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDiagnosisCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateDiagnosisCommand request, CancellationToken cancellationToken)
        {
            var diagnosis = await _unitOfWork.DiagnosisRepository.GetByIdAsync(request.Id);
            if (diagnosis == null)
            {
                throw new KeyNotFoundException($"Diagnosis with ID {request.Id} not found.");
            }

            diagnosis.Name = request.Name;
            await _unitOfWork.DiagnosisRepository.UpdateAsync(diagnosis);
            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}