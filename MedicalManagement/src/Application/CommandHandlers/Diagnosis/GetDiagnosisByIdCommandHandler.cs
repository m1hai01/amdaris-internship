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
    public class GetDiagnosisByIdCommandHandler : IRequestHandler<GetDiagnosisByIdCommand, Diagnose>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDiagnosisByIdCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Diagnose> Handle(GetDiagnosisByIdCommand request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.DiagnosisRepository.GetByIdAsync(request.Id);
        }
    }
}