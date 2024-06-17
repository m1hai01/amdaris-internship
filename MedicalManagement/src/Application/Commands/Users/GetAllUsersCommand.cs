using Domain.Models;
using MediatR;

namespace Application.Commands.Users
{
    public record GetAllUsersCommand(
        string? SearchTerm,
        string? SortColumn,
        string? SortOrder,
        int Page,
        int PageSize) : IRequest<PagedList<User>>;
}