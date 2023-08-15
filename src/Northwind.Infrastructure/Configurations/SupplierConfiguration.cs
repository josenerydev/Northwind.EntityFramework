using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Northwind.Domain.Production;

namespace Northwind.Infrastructure.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers", "Production");

            builder.HasKey(s => s.Id).HasName("PK_Suppliers");

            builder.Property(s => s.Id)
                .HasColumnName("supplierid")
                .ValueGeneratedOnAdd();

            builder.Property(s => s.CompanyName)
                .HasColumnName("companyname")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(s => s.ContactName)
                .HasColumnName("contactname")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(s => s.ContactTitle)
                .HasColumnName("contacttitle")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(s => s.Address)
                .HasColumnName("address")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(s => s.City)
                .HasColumnName("city")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(s => s.Region)
                .HasColumnName("region")
                .HasMaxLength(15);

            builder.Property(s => s.PostalCode)
                .HasColumnName("postalcode")
                .HasMaxLength(10);

            builder.Property(s => s.Country)
                .HasColumnName("country")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(s => s.Phone)
                .HasColumnName("phone")
                .HasMaxLength(24)
                .IsRequired();

            builder.Property(s => s.Fax)
                .HasColumnName("fax")
                .HasMaxLength(24);
        }
    }
}