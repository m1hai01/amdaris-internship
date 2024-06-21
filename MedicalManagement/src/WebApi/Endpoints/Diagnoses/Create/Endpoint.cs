using Application.Commands.Diagnosis;
using Carter;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints.Diagnoses.Create
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/diagnoses", Handler)
               .RequireAuthorization()
               .ProducesValidationProblem();
        }

        private async Task<IResult> Handler([FromBody] DiagnosesRequest request, IMediator mediator, IValidator<DiagnosesRequest> validator, CancellationToken cancellationToken = default)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            var command = new CreateDiagnosisCommand(request.Name, request.patientId);
            var diagnosisId = await mediator.Send(command, cancellationToken);
            return Results.Created($"/diagnoses/{diagnosisId}", diagnosisId);
        }
    }
}