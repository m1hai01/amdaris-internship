using Application.Abstractions;
using Application.Commands.Patient;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Patient
{
    internal class GetDiagnosesByPatientIdCommandHandler : IRequestHandler<GetDiagnosesByPatientIdCommand, Domain.Models.Patient>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetDiagnosesByPatientIdCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Domain.Models.Patient> Handle(GetDiagnosesByPatientIdCommand request, CancellationToken cancellationToken)
        {
            var diagnoses = await unitOfWork.PatientRepository.GetPatientWithDiagnoses(request.PatientId);
            return diagnoses;
        }
    }
}