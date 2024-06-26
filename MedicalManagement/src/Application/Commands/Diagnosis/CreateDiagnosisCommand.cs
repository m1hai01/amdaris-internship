﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Diagnosis
{
    public record CreateDiagnosisCommand(string Name, Guid patientId) : IRequest<Guid>;
}