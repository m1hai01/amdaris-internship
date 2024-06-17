using Application;
using Application.Commands.Users;
using Carter;
using MediatR;

namespace WebApi.Endpoints.Users.Get
{
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/users", HandleGetAllUsers)
               .WithName("GetAllUsers")
               .Produces<PagedList<UserResponse>>(StatusCodes.Status200OK);
        }

        private static async Task<IResult> HandleGetAllUsers(IMediator mediator, [AsParameters] GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var command = new GetAllUsersCommand(
                request.SearchTerm,
                request.SortColumn,
                request.SortOrder,
                request.Page,
                request.PageSize);

            var result = await mediator.Send(command, cancellationToken);

            return Results.Ok(result);
        }
    }
}