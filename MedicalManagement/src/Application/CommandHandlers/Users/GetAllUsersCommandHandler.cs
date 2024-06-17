using Application.Abstractions;
using Application.Commands.Users;
using Application;
using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Users
{
    public class GetAllUsersCommandHandler : IRequestHandler<GetAllUsersCommand, PagedList<User>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUsersCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<User>> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
        {
            IQueryable<User> usersQuery = _unitOfWork.UserRepository.GetAll();

            // Filtering
            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                usersQuery = usersQuery.Where(u =>
                    u.Name.Contains(request.SearchTerm) ||
                    u.Email.Contains(request.SearchTerm) ||
                    u.Username.Contains(request.SearchTerm));
            }

            // Sorting
            if (request.SortOrder?.ToLower() == "desc")
            {
                usersQuery = usersQuery.OrderByDescending(GetSortProperty(request));
            }
            else
            {
                usersQuery = usersQuery.OrderBy(GetSortProperty(request));
            }

            // Pagination
            var pagedUsers = await PagedList<User>.CreateAsync(
                usersQuery,
                request.Page,
                request.PageSize);

            return pagedUsers;
        }

        private static Expression<Func<User, object>> GetSortProperty(GetAllUsersCommand request) =>
            request.SortColumn?.ToLower() switch
            {
                "name" => user => user.Name,
                "email" => user => user.Email,
                "username" => user => user.Username,
                _ => user => user.Id
            };
    }
}