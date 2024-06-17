using Application.Commands.Users;
using AutoMapper;
using Carter;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints.Users.Create;

public class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/users", Handler)
            .RequireAuthorization()
            .ProducesValidationProblem();
    }

    private async Task<IResult> Handler([FromBody] Request request, IMediator mediator, IValidator<Request> validator, IMapper mapper, CancellationToken cancellationToken = default)
    {
        //var validationResult = validator.Validate(request);
        //if (!validationResult.IsValid)
        //{
        //    return Results.BadRequest(validationResult.Errors);
        //}
        var command = mapper.Map<CreateUserCommand>(request);

        var userId = await mediator.Send(command, cancellationToken);
        return Results.Created($"/users/{userId}", userId);
    }
}