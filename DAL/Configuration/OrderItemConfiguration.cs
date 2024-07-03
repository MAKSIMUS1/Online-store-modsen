using DAL.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(oi => oi.Quantity)
                   .IsRequired();

            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.OrderItems)
                   .HasForeignKey(oi => oi.OrderId);
        }
    }
}
