using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Northwind.Domain.Sales;

namespace Northwind.Infrastructure.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", "Sales");

            builder.HasKey(c => c.Id).HasName("PK_Customers");

            builder.Property(c => c.Id)
                .HasColumnName("custid")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.CompanyName)
                .HasColumnName("companyname")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(c => c.ContactName)
                .HasColumnName("contactname")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(c => c.ContactTitle)
                .HasColumnName("contacttitle")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(c => c.Address)
                .HasColumnName("address")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(c => c.City)
                .HasColumnName("city")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(c => c.Region)
                .HasColumnName("region")
                .HasMaxLength(15);

            builder.Property(c => c.PostalCode)
                .HasColumnName("postalcode")
                .HasMaxLength(10);

            builder.Property(c => c.Country)
                .HasColumnName("country")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(c => c.Phone)
                .HasColumnName("phone")
                .HasMaxLength(24)
                .IsRequired();

            builder.Property(c => c.Fax)
                .HasColumnName("fax")
                .HasMaxLength(24);
        }
    }
}