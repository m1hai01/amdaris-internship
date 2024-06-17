using Application.Abstractions;
using Application.Commands.Diagnosis;
using Domain.Models.Diagnosis;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Diagnosis
{
    public class GetAllDiagnosesCommandHandler : IRequestHandler<GetAllDiagnosesCommand, PagedList<Diagnose>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDiagnosesCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<Diagnose>> Handle(GetAllDiagnosesCommand request, CancellationToken cancellationToken)
        {
            IQueryable<Diagnose> diagnosesQuery = _unitOfWork.DiagnosisRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                diagnosesQuery = diagnosesQuery.Where(d => d.Name.Contains(request.SearchTerm));
            }

            if (request.SortOrder?.ToLower() == "desc")
            {
                diagnosesQuery = diagnosesQuery.OrderByDescending(GetSortProperty(request));
            }
            else
            {
                diagnosesQuery = diagnosesQuery.OrderBy(GetSortProperty(request));
            }

            return await PagedList<Diagnose>.CreateAsync(diagnosesQuery, request.Page, request.PageSize);
        }

        private static Expression<Func<Diagnose, object>> GetSortProperty(GetAllDiagnosesCommand request) =>
            request.SortColumn?.ToLower() switch
            {
                "name" => diagnosis => diagnosis.Name,
                _ => diagnosis => diagnosis.Id
            };
    }
}