using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User> 
    {
        Task<User> FindByUsernameAsync(string username, CancellationToken cancellationToken);
    }
}
