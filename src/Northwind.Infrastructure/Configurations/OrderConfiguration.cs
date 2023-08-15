using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Northwind.Domain.Sales;

namespace Northwind.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "Sales");

            builder.HasKey(o => o.Id).HasName("PK_Orders");

            builder.Property(o => o.Id)
                .HasColumnName("orderid")
                .ValueGeneratedOnAdd();

            builder.Property(o => o.CustomerId)
                .HasColumnName("custid");

            builder.Property(o => o.EmployeeId)
                .HasColumnName("empid")
                .IsRequired();

            builder.Property(o => o.OrderDate)
                .HasColumnName("orderdate")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(o => o.RequiredDate)
                .HasColumnName("requireddate")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(o => o.ShippedDate)
                .HasColumnName("shippeddate")
                .HasColumnType("date");

            builder.Property(o => o.ShipperId)
                .HasColumnName("shipperid")
                .IsRequired();

            builder.Property(o => o.Freight)
                .HasColumnName("freight")
                .HasColumnType("money")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(o => o.ShipName)
                .HasColumnName("shipname")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(o => o.ShipAddress)
                .HasColumnName("shipaddress")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(o => o.ShipCity)
                .HasColumnName("shipcity")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(o => o.ShipRegion)
                .HasColumnName("shipregion")
                .HasMaxLength(15);

            builder.Property(o => o.ShipPostalCode)
                .HasColumnName("shippostalcode")
                .HasMaxLength(10);

            builder.Property(o => o.ShipCountry)
                .HasColumnName("shipcountry")
                .HasMaxLength(15)
                .IsRequired();

            builder.HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .HasConstraintName("FK_Orders_Customers")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Employee)
                .WithMany()
                .HasForeignKey(o => o.EmployeeId)
                .HasConstraintName("FK_Orders_Employees")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Shipper)
                .WithMany()
                .HasForeignKey(o => o.ShipperId)
                .HasConstraintName("FK_Orders_Shippers")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}