using AutoMapper;
using BLL.DTO.Request.OrderItem;
using BLL.DTO.Response;
using BLL.Exceptions;
using BLL.Service.Interface;
using DAL.Model;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderItemDto>> GetAllOrderItemsAsync(CancellationToken cancellationToken = default)
        {
            var orderItems = await _orderItemRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<OrderItemDto>>(orderItems);
        }

        public async Task<OrderItemDto> GetOrderItemByIdAsync(Guid orderItemId, CancellationToken cancellationToken = default)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(orderItemId, cancellationToken);

            if (orderItem is null)
            {
                throw new EntityNotFoundException($"Order item with Id '{orderItemId}' not found.");
            }

            return _mapper.Map<OrderItemDto>(orderItem);
        }

        public async Task AddOrderItemAsync(CreateOrderItemDto orderItemDto, CancellationToken cancellationToken = default)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);
            await _orderItemRepository.AddAsync(orderItem, cancellationToken);
        }

        public async Task UpdateOrderItemAsync(UpdateOrderItemDto orderItemDto, CancellationToken cancellationToken = default)
        {
            var existingOrderItem = await _orderItemRepository.GetByIdAsync(orderItemDto.Id, cancellationToken);

            if (existingOrderItem is null)
            {
                throw new EntityNotFoundException($"Order item with Id '{orderItemDto.Id}' not found.");
            }

            _mapper.Map(orderItemDto, existingOrderItem);

            await _orderItemRepository.UpdateAsync(existingOrderItem, cancellationToken);
        }

        public async Task DeleteOrderItemAsync(Guid orderItemId, CancellationToken cancellationToken = default)
        {
            var existingOrderItem = await _orderItemRepository.GetByIdAsync(orderItemId, cancellationToken);

            if (existingOrderItem is null)
            {
                throw new EntityNotFoundException($"Order item with Id '{orderItemId}' not found.");
            }

            await _orderItemRepository.DeleteAsync(orderItemId, cancellationToken);
        }
    }
}
