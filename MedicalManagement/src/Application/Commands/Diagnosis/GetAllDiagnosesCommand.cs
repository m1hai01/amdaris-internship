using Domain.Models.Diagnosis;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Diagnosis
{
    public record GetAllDiagnosesCommand(string? SearchTerm, string? SortColumn, string? SortOrder, int Page, int PageSize) : IRequest<PagedList<Diagnose>>;
}