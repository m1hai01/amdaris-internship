using Application.Abstractions;
using Application.Commands.Diagnosis;
using Domain.Models.Diagnosis;
using Domain.Models.MedicalCard;
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
            var patient = await _unitOfWork.PatientRepository.GetByUserId(request.patientId);

            var medicalCard = await _unitOfWork.MedicalCardRepository.FindByPatientId(patient.Id);
            var myMedicalRecord = await _unitOfWork.MedicalRecordRepository.Find(medicalCard.Id);

            var diagnosis = new Diagnose { Id = Guid.NewGuid(), Name = request.Name, Treatment = null };

            var medicalRecordDiagnosis = new MedicalRecordDiagnosis { Diagnose = diagnosis };

            myMedicalRecord.Diagnoses.Add(medicalRecordDiagnosis);

            await _unitOfWork.DiagnosisRepository.AddAsync(diagnosis);
            await _unitOfWork.MedicalCardRepository.SaveChangesAsync();

            await _unitOfWork.CommitAsync();
            return diagnosis.Id;
        }
    }
}