using Domain.Models.Diagnosis;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Diagnosis
{
    public record GetDiagnosisByIdCommand(Guid Id) : IRequest<Diagnose>;
}