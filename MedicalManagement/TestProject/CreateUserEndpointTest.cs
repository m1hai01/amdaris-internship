using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Application.Commands.Users;
using Application.Abstractions;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using WebApi;
using WebApi.Endpoints.Users.Create;
using Xunit;
using FluentAssertions;
using Domain.Enums;

namespace TestProject
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

            // Add an authentication header to the client
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IlNQODlCMFZZV1NmZmJuT2N2aGtZQm1QZG8zTSJ9.eyJ2ZXIiOiIyLjAiLCJpc3MiOiJodHRwczovL2xvZ2luLm1pY3Jvc29mdG9ubGluZS5jb20vOTE4ODA0MGQtNmM2Ny00YzViLWIxMTItMzZhMzA0YjY2ZGFkL3YyLjAiLCJzdWIiOiJBQUFBQUFBQUFBQUFBQUFBQUFBQUFPdUxnZ2FuZTdrcUdJc0V2bkxXa2V3IiwiYXVkIjoiYjJjMDEzOTMtZGRkYS00NzgzLTlkMDYtYTFjZDZmNTIyYWZhIiwiZXhwIjoxNzE2ODk3OTExLCJpYXQiOjE3MTY4OTQwMTEsIm5iZiI6MTcxNjg5NDAxMSwibmFtZSI6Ik1paGFpIE0iLCJwcmVmZXJyZWRfdXNlcm5hbWUiOiJraW5nbWloYWkwMkBnbWFpbC5jb20iLCJvaWQiOiIwMDAwMDAwMC0wMDAwLTAwMDAtZjgwMy0wOTAxNmRjYzNhMjEiLCJ0aWQiOiI5MTg4MDQwZC02YzY3LTRjNWItYjExMi0zNmEzMDRiNjZkYWQiLCJhenAiOiJiMmMwMTM5My1kZGRhLTQ3ODMtOWQwNi1hMWNkNmY1MjJhZmEiLCJzY3AiOiJVc2VyLldyaXRlIE1lZGljYWxNYW5hZ2VtZW50LlJlYWQiLCJhenBhY3IiOiIwIiwidXRpIjoiVmZnRUNQMmNiazZHSEN3QUFBQUFBQSIsImFpbyI6IkRqQnJ5SEVuWHJJR0d3MmVLTUJKZ2RHRExVcVAxREp1cHpWWXZUSGRQODEhSFVFQThBcjVCZEFJVlFrN2RtcmZGejhQT0MzbTJxZE9lSE5UQTUqV2pDYTJ0WWdrQ1hGVTdqWFlqM2JpN3JiKk54ZjFSNjY1YTJxV2lXWSFNd3U3QlM3RjlFIUFxUjhxIWFxcUR5SGs3YVRCS0liR2RRUUFXQUcxbGlNazh0QjkifQ.EedriL2wIDGvdjQ-I-4CtW1ij7WhLUlfcLRMGzsaApBZJUMuTr0shJTGPS4e9nkl4H5XMN-Cvbzu_fGHKYTCXg6VhJFDXL_64S8fMjmQ5SX1LNedWFotvM60C0A554_Ks7H9Ow59618--d0EEwczti1I8F0JK1r2hsS1bO0XvXKH_r2afZeLPlXDxdwEelMDns3LNgn4T5zftY58gUe-hrU542uvzb1RaFiQnjB41LcU1NI1IjiDbXMs8NE66Qpg0XTgu2nKbEa50UMpxEFNRkDwhqqW0x_N4OL9U71kNv9-GOmUjmAlT86HttKBTYdY3PT0_LGEvLHrMYJZrhFBkQ");

            var request = new Request
            {
                Username = "string",
                Password = "string",
                Email = "string",
                Name = "string",
                DateOfBirth = new DateTime(2000, 1, 1),
                Gender = Gender.Male,
                PhoneNumber = "string"
            };

            var expectedUserId = Guid.NewGuid();
            var user = new User
            {
                Id = expectedUserId,
                Username = request.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Email = request.Email,
                Name = request.Name,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                PhoneNumber = request.PhoneNumber
            };

            _unitOfWorkMock.Setup(u => u.UserRepository.CreateUserAsync(It.IsAny<User>())).Returns(Task.CompletedTask)
                           .Callback<User>(u => u.Id = expectedUserId); // Set the Id of the user being created
            _unitOfWorkMock.Setup(u => u.CommitAsync()).Returns(Task.FromResult(1)); // Mock commit method to return 1

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