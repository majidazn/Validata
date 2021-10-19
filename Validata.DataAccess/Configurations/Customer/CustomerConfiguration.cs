using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Validata.Domain.CustomerAggregate.ValueObjects;

namespace Validata.DataAccess.Configurations.Customer
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Domain.CustomerAggregate.Entities.Customer>
    {
        public void Configure(EntityTypeBuilder<Domain.CustomerAggregate.Entities.Customer> builder)
        {
            builder.ToTable("Customers", "Validata");

            builder.HasKey(d => d.Id);

            builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Address).HasMaxLength(200).IsRequired();


            builder.Property(x => x.PostalCode).HasConversion(
             new ValueConverter<PostalCode, string>(postalCode => postalCode.Value,
                        value => PostalCode.Create(value)));


            builder.HasIndex(p => p.Status);
        }
    }
}
