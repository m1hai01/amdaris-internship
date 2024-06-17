using Application.Commands.Diagnosis;
using Carter;
using MediatR;

namespace WebApi.Endpoints.Diagnoses.Delete
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/diagnoses/{id}", Handler)
               .RequireAuthorization()
               .ProducesValidationProblem();
        }

        private async Task<IResult> Handler(Guid id, IMediator mediator, CancellationToken cancellationToken = default)
        {
            var command = new DeleteDiagnosisCommand(id);
            await mediator.Send(command, cancellationToken);
            return Results.NoContent();
        }
    }
}