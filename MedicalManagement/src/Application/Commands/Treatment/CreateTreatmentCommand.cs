using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Treatment
{
    public record CreateTreatmentCommand(string Name, Guid? DiagnosisId, int Duration, DurationUnit DurationUnit) : IRequest<Guid>;
}