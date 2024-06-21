using Application.Commands.Treatment;
using AutoMapper;
using Carter;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints.Treatments.Update
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/treatments/{id}", Handler)
               .RequireAuthorization()
               .ProducesValidationProblem();
        }

        private async Task<IResult> Handler(Guid id, [FromBody] TreatmentUpdateRequest request, IMediator mediator, IValidator<TreatmentUpdateRequest> validator, IMapper mapper, CancellationToken cancellationToken = default)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            var command = mapper.Map<UpdateTreatmentCommand>(request);
            await mediator.Send(command, cancellationToken);

            return Results.NoContent();
        }
    }
}