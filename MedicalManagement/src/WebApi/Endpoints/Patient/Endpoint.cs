using Application.Commands.Patient;
using AutoMapper;
using Carter;
using FluentValidation;
using MediatR;

namespace WebApi.Endpoints.Patient
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/patients", Handler)
               .RequireAuthorization()
               .ProducesValidationProblem()
               .WithName("CreatePatient")
               .Produces<CreatePatientResponse>(StatusCodes.Status201Created);
        }

        private async Task<IResult> Handler(CreatePatientRequest request, IMediator mediator, IValidator<CreatePatientRequest> validator, IMapper mapper, CancellationToken cancellationToken)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            var command = mapper.Map<CreatePatientCommand>(request);
            var patientId = await mediator.Send(command, cancellationToken);
            var response = new CreatePatientResponse(patientId);

            return Results.Created($"/patients/{response.Id}", response);
        }
    }
}