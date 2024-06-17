using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.Commands.Users;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.CommandHandlers.Users
{
    public class GetUserByIdCommandHandler : IRequestHandler<GetUserByIdCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserByIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<User> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            return user;
        }
    }
}