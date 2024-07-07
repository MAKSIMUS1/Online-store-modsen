using AutoMapper;
using BLL.DTO.Request.Order;
using BLL.DTO.Response;
using BLL.Exceptions;
using BLL.Service.Interface;
using DAL.Model;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync(CancellationToken cancellationToken = default)
        {
            var orders = await _orderRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken = default)
        {
            var order = await _orderRepository.GetOrderDetailsAsync(orderId, cancellationToken);

            if (order is null)
            {
                throw new EntityNotFoundException($"Order with Id '{orderId}' not found.");
            }

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var orders = await _orderRepository.GetByUserIdAsync(userId, cancellationToken);
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task AddOrderAsync(CreateOrderDto orderDto, CancellationToken cancellationToken = default)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.AddAsync(order, cancellationToken);
        }

        public async Task UpdateOrderAsync(UpdateOrderDto orderDto, CancellationToken cancellationToken = default)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(orderDto.UserId, cancellationToken);

            if (existingOrder is null)
            {
                throw new EntityNotFoundException($"Order with Id '{orderDto.UserId}' not found.");
            }

            _mapper.Map(orderDto, existingOrder);

            await _orderRepository.UpdateAsync(existingOrder, cancellationToken);
        }

        public async Task DeleteOrderAsync(Guid orderId, CancellationToken cancellationToken = default)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(orderId, cancellationToken);

            if (existingOrder is null)
            {
                throw new EntityNotFoundException($"Order with Id '{orderId}' not found.");
            }

            await _orderRepository.DeleteAsync(orderId, cancellationToken);
        }
    }
}
