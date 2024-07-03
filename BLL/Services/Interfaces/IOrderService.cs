using BLL.DTO.Request.Order;
using BLL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync(CancellationToken cancellationToken);
        Task<OrderDto> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken);
        Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(Guid userId, CancellationToken cancellationToken);
        Task AddOrderAsync(CreateOrderDto orderDto, CancellationToken cancellationToken);
        Task UpdateOrderAsync(UpdateOrderDto orderDto, CancellationToken cancellationToken);
        Task DeleteOrderAsync(Guid orderId, CancellationToken cancellationToken);
    }
}
