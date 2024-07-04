using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category> 
    {
        Task<Category> FindByNameAsync(string name, CancellationToken cancellationToken);
    }
}
