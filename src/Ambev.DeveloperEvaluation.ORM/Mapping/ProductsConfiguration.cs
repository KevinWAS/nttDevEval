using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductsConfiguration : IEntityTypeConfiguration<Products>
{
    public void Configure(EntityTypeBuilder<Products> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(u => u.CartId).HasColumnType("uuid");
        builder.Property(u => u.Title).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Description);
        builder.Property(u => u.Price).HasColumnType("numeric");
        builder.Property(u => u.ratingCount).HasColumnType("integer");
        builder.Property(u => u.ratingRate).HasColumnType("numeric");
        builder.Property(u => u.CreatedAt).HasColumnType("date");
        builder.Property(u => u.UpdatedAt).HasColumnType("date");

        builder.HasOne<Carts>()
            .WithMany()
            .HasForeignKey(u => u.CartId);

    }
}
