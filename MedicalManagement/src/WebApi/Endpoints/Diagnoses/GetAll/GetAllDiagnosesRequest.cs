using Application;
using Domain.Models.Diagnosis;
using MediatR;

namespace WebApi.Endpoints.Diagnoses.GetAll
{
    public class GetAllDiagnosesRequest : IRequest<PagedList<Diagnose>>
    {
        public string? SearchTerm { get; set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}