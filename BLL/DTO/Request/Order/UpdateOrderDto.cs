using BLL.DTO.Request.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Request.Order
{
    public class UpdateOrderDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
