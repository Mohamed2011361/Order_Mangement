using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderCust>
    {
        public void Configure(EntityTypeBuilder<OrderCust> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.OrderDate)
                .IsRequired();
            builder.Property(o => o.TotalAmount)
                .IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(o => o.PaymentMethod)
                .IsRequired();
            builder.Property(o => o.Status)
                .IsRequired();
        }
    }
}
