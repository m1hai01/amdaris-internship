using Application;
using Application.Commands.Diagnosis;
using Carter;
using Domain.Models.Diagnosis;
using MediatR;

namespace WebApi.Endpoints.Diagnoses.GetAll
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/diagnoses", async (IMediator mediator, [AsParameters] GetAllDiagnosesRequest request, CancellationToken cancellationToken) =>
            {
                var query = new GetAllDiagnosesCommand(
                    request.SearchTerm,
                    request.SortColumn,
                    request.SortOrder,
                    request.Page,
                    request.PageSize);

                var result = await mediator.Send(query, cancellationToken);
                return Results.Ok(result);
            })
            .WithName("GetAllDiagnoses")
            .Produces<PagedList<Diagnose>>(StatusCodes.Status200OK);
        }
    }
}