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
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantity)
                .IsRequired();
            builder.Property(x => x.UnitPrice)
                .HasColumnType("decimal(18,2)");
            builder.Property(x => x.Discount)
                .HasColumnType("decimal(18,2)");
        

        }
    }
}
