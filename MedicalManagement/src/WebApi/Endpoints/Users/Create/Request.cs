using Domain.Enums;

namespace WebApi.Endpoints.Users.Create
{
    public class Request
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; } = null!;
    }
}