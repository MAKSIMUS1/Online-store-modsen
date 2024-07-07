using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{

    public interface IUserRepository : IBaseRepository<User> { }

    public interface IUserRepository : IBaseRepository<User> 
    {
        Task<User> FindByUsernameAsync(string username, CancellationToken cancellationToken);

        Task<User> LoginAsync(string email, string passwordHash, CancellationToken cancellationToken);

    }


    public interface IUserRepository : IBaseRepository<User> 
    {
        Task<User> FindByUsernameAsync(string username, CancellationToken cancellationToken);
    }

}
