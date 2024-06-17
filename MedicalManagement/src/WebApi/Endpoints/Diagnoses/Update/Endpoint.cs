using Application.Commands.Diagnosis;
using Carter;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints.Update
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/diagnoses/{id}", Handler)
               .RequireAuthorization()
               .ProducesValidationProblem();
        }

        private async Task<IResult> Handler(Guid id, [FromBody] UpdateRequest request, IMediator mediator, CancellationToken cancellationToken = default)
        {
            var command = new UpdateDiagnosisCommand(id, request.Name);
            await mediator.Send(command, cancellationToken);
            return Results.NoContent();
        }
    }
}