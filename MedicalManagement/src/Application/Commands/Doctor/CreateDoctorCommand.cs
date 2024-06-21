using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Doctor
{
    public record CreateDoctorCommand(
        Guid UserId,
        List<string> JobRoles,
        List<DateTime> AvailableHours
    ) : IRequest<Guid>;
}