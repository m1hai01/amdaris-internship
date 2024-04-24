using Application.Abstractions;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MedicalManagementDbContext _dbContext;

        public UserRepository(MedicalManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task CreateUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await GetUserByIdAsync(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}