using Application.Commands.Users;
using Carter;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Endpoints.Users.GetById
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/users/{userId:guid}", async (Guid userId, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var command = new GetUserByIdCommand(userId);
                var result = await mediator.Send(command, cancellationToken);
                return Results.Ok(result);
            })
            .WithName("GetUserById")
            .Produces<User>(StatusCodes.Status200OK);
        }
    }
}