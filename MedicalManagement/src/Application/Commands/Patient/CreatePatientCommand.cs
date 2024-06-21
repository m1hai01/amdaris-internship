using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Patient
{
    public record CreatePatientCommand : IRequest<Guid>
    {
        public Guid UserId { get; init; }

        public CreatePatientCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}