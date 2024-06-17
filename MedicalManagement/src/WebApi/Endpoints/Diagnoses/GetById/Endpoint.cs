using Application.Commands.Diagnosis;
using Carter;
using MediatR;

namespace WebApi.Endpoints.Diagnoses.GetById
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/diagnoses/{id}", Handler)
               .RequireAuthorization()
               .ProducesValidationProblem();
        }

        private async Task<IResult> Handler(Guid id, IMediator mediator, CancellationToken cancellationToken = default)
        {
            var query = new GetDiagnosisByIdCommand(id);
            var diagnosis = await mediator.Send(query, cancellationToken);
            return diagnosis != null ? Results.Ok(diagnosis) : Results.NotFound();
        }
    }
}