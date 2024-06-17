using Application.Abstractions;
using Application.Commands.Diagnosis;
using Domain.Models.Diagnosis;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Diagnosis
{
    public class CreateDiagnosisCommandHandler : IRequestHandler<CreateDiagnosisCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDiagnosisCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateDiagnosisCommand request, CancellationToken cancellationToken)
        {
            var diagnosis = new Diagnose { Id = Guid.NewGuid(), Name = request.Name };
            await _unitOfWork.DiagnosisRepository.AddAsync(diagnosis);
            await _unitOfWork.CommitAsync();
            return diagnosis.Id;
        }
    }
}