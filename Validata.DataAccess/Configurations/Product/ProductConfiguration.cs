using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.Domain.ProductAggregate.ValueObjects;

namespace Validata.DataAccess.Configurations.Product
{
    public class ProductConfiguration : IEntityTypeConfiguration<Domain.ProductAggregate.Entities.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.ProductAggregate.Entities.Product> builder)
        {
            builder.ToTable("Products", "Validata");

            builder.HasKey(d => d.Id);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Price).HasConversion(
       new ValueConverter<Price, decimal>(price => price.Value,
                  value => Price.Create(value)));


            builder.HasIndex(p => p.Status);

        }
    }
}
