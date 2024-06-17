using Domain.Enums;
using System;

namespace WebApi.Endpoints.Users.Get
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

        public UserResponse(Guid id, string username, string email, string name, DateTime dateOfBirth, Gender gender, string phoneNumber)
        {
            Id = id;
            Username = username;
            Email = email;
            Name = name;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PhoneNumber = phoneNumber;
        }
    }
}