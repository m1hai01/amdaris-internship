using Application.Commands.Treatment;
using AutoMapper;
using Carter;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints.Treatments.Create
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/treatments", Handler)
               .RequireAuthorization()
               .ProducesValidationProblem();
        }

        private async Task<IResult> Handler([FromBody] TreatmentCreateRequest request, IMediator mediator, IValidator<TreatmentCreateRequest> validator, IMapper mapper, CancellationToken cancellationToken = default)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            var command = mapper.Map<CreateTreatmentCommand>(request);
            var treatmentId = await mediator.Send(command, cancellationToken);

            return Results.Created($"/treatments/{treatmentId}", new TreatmentCreateResponse(treatmentId));
        }
    }
}