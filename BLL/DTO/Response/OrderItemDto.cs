﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Response
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
