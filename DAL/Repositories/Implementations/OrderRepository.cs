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
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(o => o.UserId == userId).ToListAsync(cancellationToken);
        }

        public async Task<Order> GetOrderDetailsAsync(Guid orderId, CancellationToken cancellationToken)
        {
            return await _dbSet.Include(o => o.OrderItems)
                               .ThenInclude(oi => oi.Product)
                               .FirstOrDefaultAsync(o => o.Id == orderId, cancellationToken);
        }
    }
}
