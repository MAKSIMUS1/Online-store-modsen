using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetByCategoryAsync(Guid categoryId, CancellationToken cancellationToken);
    }
}
