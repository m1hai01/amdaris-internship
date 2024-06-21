using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IDoctorRepository
    {
        Task<Doctor> GetByIdAsync(Guid id);

        IQueryable<Doctor> GetAll();

        Task AddAsync(Doctor doctor);

        Task UpdateAsync(Doctor doctor);

        Task DeleteAsync(Guid id);
    }
}