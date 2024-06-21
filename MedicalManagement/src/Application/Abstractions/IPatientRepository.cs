using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IPatientRepository
    {
        Task<Patient> GetByIdAsync(Guid id);
        Task<Patient> GetByUserId(Guid id);
        Task<Patient> GetPatientWithDiagnoses(Guid id);

        IQueryable<Patient> GetAll();

        Task AddAsync(Patient patient);

        Task UpdateAsync(Patient patient);

        Task DeleteAsync(Guid id);
    }
}