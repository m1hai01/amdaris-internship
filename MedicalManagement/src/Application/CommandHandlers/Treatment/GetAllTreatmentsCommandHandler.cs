using Application.Abstractions;
using Application.Commands.Treatment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Treatment
{
    public class GetAllTreatmentsCommandHandler : IRequestHandler<GetAllTreatmentsCommand, PagedList<Domain.Models.Diagnosis.Treatment>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTreatmentsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<Domain.Models.Diagnosis.Treatment>> Handle(GetAllTreatmentsCommand request, CancellationToken cancellationToken)
        {
            IQueryable<Domain.Models.Diagnosis.Treatment> treatmentsQuery = _unitOfWork.TreatmentRepository.GetAll();

            // Filtering
            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                treatmentsQuery = treatmentsQuery.Where(t =>
                    t.Name.Contains(request.SearchTerm));
            }

            // Sorting
            if (request.SortOrder?.ToLower() == "desc")
            {
                treatmentsQuery = treatmentsQuery.OrderByDescending(GetSortProperty(request));
            }
            else
            {
                treatmentsQuery = treatmentsQuery.OrderBy(GetSortProperty(request));
            }

            // Pagination
            var pagedTreatments = await PagedList<Domain.Models.Diagnosis.Treatment>.CreateAsync(
                treatmentsQuery,
                request.Page,
                request.PageSize);

            return pagedTreatments;
        }

        private static Expression<Func<Domain.Models.Diagnosis.Treatment, object>> GetSortProperty(GetAllTreatmentsCommand request) =>
            request.SortColumn?.ToLower() switch
            {
                "name" => treatment => treatment.Name,
                _ => treatment => treatment.Id
            };
    }
}