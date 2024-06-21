using Application.Commands.Patient;
using Application.Commands.Users;
using AutoMapper;
using Carter;
using FluentValidation;
using MediatR;

namespace WebApi.Endpoints.Patient.GetDiagnosesByPatientId
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/patient/diagnoses/{patientId:guid}", async (Guid patientId, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var command = new GetDiagnosesByPatientIdCommand(patientId);
                var result = await mediator.Send(command, cancellationToken);
                return Results.Ok(result);
            })
            .WithName("GetDiagnosesByPatientIdRequest")
            .Produces<Domain.Models.Patient>(StatusCodes.Status200OK);
        }
    }
}