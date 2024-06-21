using Application.Abstractions;
using Application.Commands.Doctor;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Docor
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDoctorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var availableHours = new List<TimeSpan>(request.AvailableHours.Count);

            foreach (var ts in request.AvailableHours)
            {
                availableHours.Add(TimeSpan.FromTicks(ts.Ticks));
            }

            var doctor = new Doctor
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                JobRoles = request.JobRoles,
                AvailableHours = availableHours
            };

            await _unitOfWork.DoctorRepository.AddAsync(doctor);
            await _unitOfWork.CommitAsync();

            return doctor.Id;
        }
    }
}