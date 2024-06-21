using Application.Commands.Doctor;
using AutoMapper;
using Carter;
using FluentValidation;
using MediatR;

namespace WebApi.Endpoints.Doctor
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/doctors", Handler)
               .RequireAuthorization()
               .ProducesValidationProblem()
               .WithName("CreateDoctor")
               .Produces<CreateDoctorResponse>(StatusCodes.Status201Created);
        }

        private async Task<IResult> Handler(CreateDoctorRequest request, IMediator mediator, IValidator<CreateDoctorRequest> validator, IMapper mapper, CancellationToken cancellationToken)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            var command = mapper.Map<CreateDoctorCommand>(request);
            var doctorId = await mediator.Send(command, cancellationToken);
            var response = new CreateDoctorResponse(doctorId);

            return Results.Created($"/doctors/{response.Id}", response);
        }
    }
}