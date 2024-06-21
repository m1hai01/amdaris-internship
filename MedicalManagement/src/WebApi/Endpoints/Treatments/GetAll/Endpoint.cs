using Application;
using Application.Commands.Treatment;
using Carter;
using MediatR;

namespace WebApi.Endpoints.Treatments.GetAll
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/treatments", async (IMediator mediator, [AsParameters] TreatmentGetAllRequest request, CancellationToken cancellationToken) =>
            {
                var command = new GetAllTreatmentsCommand(
                    request.SearchTerm,
                    request.SortColumn,
                    request.SortOrder,
                    request.Page,
                    request.PageSize);

                var result = await mediator.Send(command, cancellationToken);

                var response = result.Data.Select(t => new TreatmentGetAllResponse(t)).ToList();
                var pagedResponse = new PagedList<TreatmentGetAllResponse>(response, result.Page, result.PageSize, result.TotalCount);

                return Results.Ok(pagedResponse);
            })
           .WithName("GetAllTreatments")
           .Produces<PagedList<TreatmentGetAllResponse>>(StatusCodes.Status200OK);
        }
    }
}