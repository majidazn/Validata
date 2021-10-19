using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Domain.OrderAggregate.ValueObjects;

namespace Validata.DataAccess.Configurations.Order
{
    public class OrderConfiguration : IEntityTypeConfiguration<Domain.OrderAggregate.Entities.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.OrderAggregate.Entities.Order> builder)
        {
            builder.ToTable("Orders", "Validata");

            builder.HasKey(d => d.Id);


            builder.Property(x => x.TotalPrice).HasConversion(
          new ValueConverter<TotalPrice, decimal>(totalPrice => totalPrice.Value,
                     value => TotalPrice.Create(value)));

            builder.HasIndex(p => p.Status);

        }
    }
}
