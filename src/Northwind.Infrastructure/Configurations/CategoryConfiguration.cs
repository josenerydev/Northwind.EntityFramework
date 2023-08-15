using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Northwind.Domain.Production;

namespace Northwind.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "Production");

            builder.HasKey(c => c.Id).HasName("PK_Categories");

            builder.Property(c => c.Id)
                .HasColumnName("categoryid")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.CategoryName)
                .HasColumnName("categoryname")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnName("description")
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}