using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace WebApi.Endpoints.Users.Create
{
    public class Request
    {
        public string Username { get; set; } = null!;

        [Required]
        [MinLength(8)]
        public string Password { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        [Phone]
        public string PhoneNumber { get; set; } = null!;
    }
}