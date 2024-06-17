using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(Guid id);

        IQueryable<User> GetAll();

        Task CreateUserAsync(User user);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(Guid id);
    }
}