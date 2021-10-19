using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validata.DataAccess.Configurations.Order
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<Domain.OrderAggregate.Entities.OrderItem>
    {
        public void Configure(EntityTypeBuilder<Domain.OrderAggregate.Entities.OrderItem> builder)
        {
            builder.ToTable("OrderItems", "Validata");

            builder.HasKey(d => d.Id);
            builder.Property(p => p.Quantity).IsRequired();


            builder.HasIndex(p => p.Status);
        }
    }
}
