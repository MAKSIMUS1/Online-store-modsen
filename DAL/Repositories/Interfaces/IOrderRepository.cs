using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<Order> GetOrderDetailsAsync(Guid orderId, CancellationToken cancellationToken);
    }
}
