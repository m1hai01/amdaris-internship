using Application.Abstractions;
using Application.Commands.Users;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Hash the password before storing it in the database
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Username = request.Username,
                Password = hashedPassword,
                Email = request.Email,
                Name = request.Name,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                PhoneNumber = request.PhoneNumber
            };

            await _unitOfWork.UserRepository.CreateUserAsync(user);
            await _unitOfWork.CommitAsync();

            return user.Id;
        }
    }
}