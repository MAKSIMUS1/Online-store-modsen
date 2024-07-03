using BLL.DTO.Request.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BLL.DTO.Request.Order
{
    public class CreateOrderDto
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
