using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        //other repository properties

        Task<int> CommitAsync();
    }
}