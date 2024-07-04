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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }
        public async Task<Category> FindByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Name == name, cancellationToken);
        }

    }
}
