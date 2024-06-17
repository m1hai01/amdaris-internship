using Application;
using Domain.Models;
using MediatR;

namespace WebApi.Endpoints.Users.Get
{
    public class GetAllUsersRequest : IRequest<PagedList<User>>
    {
        public string? SearchTerm { get; set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}