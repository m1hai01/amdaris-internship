using Application.Abstractions;
using Application.CommandHandlers.Users;
using Application.Commands.Users;
using Domain.Enums;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class CreateUserCommandHandlerTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly CreateUserCommandHandler _handler;

        public CreateUserCommandHandlerTest()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new CreateUserCommandHandler(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateUserAndReturnUserId()
        {
            // Arrange
            var command = new CreateUserCommand
            {
                Username = "testuser",
                Password = "password",
                Email = "test@example.com",
                Name = "Test User",
                DateOfBirth = new DateTime(2000, 1, 1),
                Gender = Gender.Male,
                PhoneNumber = "1234567890"
            };

            var expectedUserId = Guid.NewGuid();
            var user = new User
            {
                Id = expectedUserId,
                Username = command.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(command.Password),
                Email = command.Email,
                Name = command.Name,
                DateOfBirth = command.DateOfBirth,
                Gender = command.Gender,
                PhoneNumber = command.PhoneNumber
            };

            _unitOfWorkMock.Setup(u => u.UserRepository.CreateUserAsync(It.IsAny<User>())).Returns(Task.CompletedTask)
                           .Callback<User>(u => u.Id = expectedUserId); // Set the Id of the user being created
            _unitOfWorkMock.Setup(u => u.CommitAsync()).Returns(Task.FromResult(1)); // Mock commit method to return 1

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(expectedUserId, result);
            _unitOfWorkMock.Verify(u => u.UserRepository.CreateUserAsync(It.IsAny<User>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
        }
    }
}