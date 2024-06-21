using Application.Abstractions;
using Application.Commands.Patient;
using Domain.Models.MedicalCard;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Patient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePatientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = new Domain.Models.Patient
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId
            };

            var medicalCard = new MedicalCard
            {
                Id = Guid.NewGuid(),
                PatientId = patient.Id,
                //State = "New",
                //MedicalRecords = new List<MedicalRecord>()
            };

            var medicalRecord = new MedicalRecord
            {
                Id = Guid.NewGuid(),
                MedicalCardId = medicalCard.Id,
                Notes = "Initial record",
                //Symptoms = new List<MedicalRecordSymptom>(),
                //Diagnoses = new List<MedicalRecordDiagnosis>(),
                //Treatment = new MedicalRecordTreatment(),
                //Files = new List<File>()
            };

            medicalCard.MedicalRecords.Add(medicalRecord);
            patient.MedicalCardId = medicalCard.Id;
            patient.MedicalCard = medicalCard;

            await _unitOfWork.PatientRepository.AddAsync(patient);
            await _unitOfWork.MedicalCardRepository.AddAsync(medicalCard);
            await _unitOfWork.MedicalRecordRepository.AddAsync(medicalRecord);

            await _unitOfWork.CommitAsync();

            return patient.Id;
        }
    }
}