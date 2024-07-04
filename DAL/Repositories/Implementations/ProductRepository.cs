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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(Guid categoryId, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(p => p.Id == categoryId).ToListAsync(cancellationToken);
        }
        public async Task<Product> FindByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Name == name, cancellationToken);
        }
    }
}
