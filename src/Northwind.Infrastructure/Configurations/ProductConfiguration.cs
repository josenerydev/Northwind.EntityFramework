using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Northwind.Domain.Production;

namespace Northwind.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "Production");

            builder.HasKey(p => p.Id).HasName("PK_Products");

            builder.Property(p => p.Id)
                .HasColumnName("productid")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ProductName)
                .HasColumnName("productname")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(p => p.SupplierId)
                .HasColumnName("supplierid")
                .IsRequired();

            builder.Property(p => p.CategoryId)
                .HasColumnName("categoryid")
                .IsRequired();

            builder.Property(p => p.UnitPrice)
                .HasColumnName("unitprice")
                .HasColumnType("money")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(p => p.Discontinued)
                .HasColumnName("discontinued")
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .HasConstraintName("FK_Products_Categories")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Supplier)
                .WithMany()
                .HasForeignKey(p => p.SupplierId)
                .HasConstraintName("FK_Products_Suppliers")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasCheckConstraint("CHK_Products_unitprice", "[unitprice]>=(0)");
        }
    }
}