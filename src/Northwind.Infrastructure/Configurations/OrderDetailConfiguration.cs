using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Northwind.Domain.Sales;

namespace Northwind.Infrastructure.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails", "Sales");

            builder.HasKey(od => new { od.OrderId, od.ProductId }).HasName("PK_OrderDetails");

            builder.Property(od => od.OrderId)
                .HasColumnName("orderid");

            builder.Property(od => od.ProductId)
                .HasColumnName("productid");

            builder.Property(od => od.UnitPrice)
                .HasColumnName("unitprice")
                .HasColumnType("money")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(od => od.Quantity)
                .HasColumnName("qty")
                .HasColumnType("smallint")
                .HasDefaultValue(1)
                .IsRequired();

            builder.Property(od => od.Discount)
                .HasColumnName("discount")
                .HasColumnType("numeric(4, 3)")
                .HasDefaultValue(0)
                .IsRequired();

            builder.HasOne(od => od.Order)
                .WithMany()
                .HasForeignKey(od => od.OrderId)
                .HasConstraintName("FK_OrderDetails_Orders")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.ProductId)
                .HasConstraintName("FK_OrderDetails_Products")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasCheckConstraint("CHK_discount", "[discount]>=0 AND [discount]<=1");
            builder.HasCheckConstraint("CHK_qty", "[qty]>0");
            builder.HasCheckConstraint("CHK_unitprice", "[unitprice]>=0");
        }
    }
}