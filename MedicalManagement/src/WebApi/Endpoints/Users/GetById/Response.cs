// WebApi/Endpoints/Users/GetById/Response.
using Domain.Enums;
using Domain.Models;

namespace WebApi.Endpoints.Users.GetById
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }

        public UserResponse(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            Name = user.Name;
            DateOfBirth = user.DateOfBirth;
            Gender = user.Gender;
            PhoneNumber = user.PhoneNumber;
        }
    }
}