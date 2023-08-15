using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Northwind.Domain.HR;

namespace Northwind.Infrastructure.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees", "HR");

            builder.HasKey(e => e.Id).HasName("PK_Employees");

            builder.Property(e => e.Id)
                .HasColumnName("empid")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.LastName)
                .HasColumnName("lastname")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.FirstName)
                .HasColumnName("firstname")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.TitleOfCourtesy)
                .HasColumnName("titleofcourtesy")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(e => e.BirthDate)
                .HasColumnName("birthdate")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.HireDate)
                .HasColumnName("hiredate")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.Address)
                .HasColumnName("address")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(e => e.City)
                .HasColumnName("city")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(e => e.Region)
                .HasColumnName("region")
                .HasMaxLength(15);

            builder.Property(e => e.PostalCode)
                .HasColumnName("postalcode")
                .HasMaxLength(10);

            builder.Property(e => e.Country)
                .HasColumnName("country")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(e => e.Phone)
                .HasColumnName("phone")
                .HasMaxLength(24)
                .IsRequired();

            builder.Property(e => e.ManagerId)
                .HasColumnName("mgrid");

            builder.HasOne(e => e.Manager)
                .WithMany(m => m.Subordinates)
                .HasForeignKey(e => e.ManagerId)
                .HasConstraintName("FK_Employees_Employees")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasCheckConstraint("CHK_birthdate", "[birthdate]<=CONVERT([date],sysdatetime())");
        }
    }
}