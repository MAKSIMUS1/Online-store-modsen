using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.DTO.Request.Order;
using BLL.DTO.Response;
using BLL.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders(CancellationToken cancellationToken)
        {
            var orders = await _orderService.GetAllOrdersAsync(cancellationToken);
            return Ok(orders);
        }

        // GET: api/order/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(Guid id, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetOrderByIdAsync(id, cancellationToken);
            return Ok(order);
        }

        // GET: api/order/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByUser(Guid userId, CancellationToken cancellationToken)
        {
            var orders = await _orderService.GetOrdersByUserIdAsync(userId, cancellationToken);
            return Ok(orders);
        }

        // POST: api/order
        [HttpPost]
        public async Task<ActionResult> AddOrder([FromBody] CreateOrderDto orderDto, CancellationToken cancellationToken)
        {
            await _orderService.AddOrderAsync(orderDto, cancellationToken);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/order/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(Guid id, [FromBody] UpdateOrderDto orderDto, CancellationToken cancellationToken)
        {
            orderDto.Id = id;
            await _orderService.UpdateOrderAsync(orderDto, cancellationToken);
            return NoContent();
        }

        // DELETE: api/order/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(Guid id, CancellationToken cancellationToken)
        {
            await _orderService.DeleteOrderAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
