using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User : BaseEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null;
        public string Password { get; set; } = null;
        public string Email { get; set; } = null;
        public string Name { get; set; } = null;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string? PhoneNumber { get; set; }
    }
}