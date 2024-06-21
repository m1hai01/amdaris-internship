using Application.Commands.Treatment;
using Carter;
using MediatR;

namespace WebApi.Endpoints.Treatments.Delete
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/treatments/{id}", Handler)
               .RequireAuthorization();
        }

        private async Task<IResult> Handler(Guid id, IMediator mediator, CancellationToken cancellationToken = default)
        {
            var command = new DeleteTreatmentCommand(id);
            await mediator.Send(command, cancellationToken);
            return Results.NoContent();
        }
    }
}