using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Application.Commands.Users;
using Application.Abstractions;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using WebApi;
using WebApi.Endpoints.Users.Create;
using Xunit;
using FluentAssertions;
using Domain.Enums;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace IntegrationTests
{
    public class CreateUserEndpointTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public CreateUserEndpointTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _factory = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => _unitOfWorkMock.Object);
                });
            });
        }

        [Fact]
        public async Task Post_CreateUser_ShouldReturnCreated()
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = new Request
            {
                Username = "testuser",
                Password = "password",
                Email = "test@example.com",
                Name = "Test User",
                DateOfBirth = new DateTime(2000, 1, 1),
                Gender = Gender.Male,
                PhoneNumber = "1234567890"
            };

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Email = request.Email,
                Name = request.Name,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                PhoneNumber = request.PhoneNumber
            };

            _unitOfWorkMock.Setup(u => u.UserRepository.CreateUserAsync(It.IsAny<User>())).Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(u => u.CommitAsync()).Returns((Task<int>)Task.CompletedTask);

            // Act
            var response = await client.PostAsJsonAsync("/users", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var createdUserId = await response.Content.ReadFromJsonAsync<Guid>();
            createdUserId.Should().Be(user.Id);

            _unitOfWorkMock.Verify(u => u.UserRepository.CreateUserAsync(It.IsAny<User>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
        }
    }
}