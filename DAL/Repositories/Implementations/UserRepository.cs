using DAL.Data;
using DAL.Model;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<User> FindByUsernameAsync(string username, CancellationToken cancellationToken)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Username == username, cancellationToken);
        }


        public async Task<User> LoginAsync(string email, string passwordHash, CancellationToken cancellationToken)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == passwordHash, cancellationToken);
        }

    }
}
