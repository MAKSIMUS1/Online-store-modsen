using BLL.DTO.Request.OrderItem;
using BLL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Interface
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemDto>> GetAllOrderItemsAsync(CancellationToken cancellationToken);
        Task<OrderItemDto> GetOrderItemByIdAsync(Guid orderItemId, CancellationToken cancellationToken);
        Task AddOrderItemAsync(CreateOrderItemDto orderItemDto, CancellationToken cancellationToken);
        Task UpdateOrderItemAsync(UpdateOrderItemDto orderItemDto, CancellationToken cancellationToken);
        Task DeleteOrderItemAsync(Guid orderItemId, CancellationToken cancellationToken);
    }
}
