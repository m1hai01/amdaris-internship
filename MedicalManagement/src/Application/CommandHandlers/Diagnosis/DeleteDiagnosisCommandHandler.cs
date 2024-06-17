using Application.Abstractions;
using Application.Commands.Diagnosis;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Diagnosis
{
    public class DeleteDiagnosisCommandHandler : IRequestHandler<DeleteDiagnosisCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDiagnosisCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteDiagnosisCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.DiagnosisRepository.DeleteAsync(request.Id);
            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}