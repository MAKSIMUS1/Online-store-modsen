using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.DTO.Request.OrderItem;
using BLL.DTO.Response;
using BLL.Service.Interface;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        // GET: api/orderitem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetOrderItems(CancellationToken cancellationToken)
        {
            var orderItems = await _orderItemService.GetAllOrderItemsAsync(cancellationToken);
            return Ok(orderItems);
        }

        // GET: api/orderitem/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemDto>> GetOrderItem(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var orderItem = await _orderItemService.GetOrderItemByIdAsync(id, cancellationToken);
                return Ok(orderItem);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/orderitem
        [HttpPost]
        public async Task<ActionResult> AddOrderItem([FromBody] CreateOrderItemDto orderItemDto, CancellationToken cancellationToken)
        {
            await _orderItemService.AddOrderItemAsync(orderItemDto, cancellationToken);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/orderitem/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrderItem(Guid id, [FromBody] UpdateOrderItemDto orderItemDto, CancellationToken cancellationToken)
        {
            try
            {
                orderItemDto.Id = id; 
                await _orderItemService.UpdateOrderItemAsync(orderItemDto, cancellationToken);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/orderitem/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrderItem(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _orderItemService.DeleteOrderItemAsync(id, cancellationToken);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
