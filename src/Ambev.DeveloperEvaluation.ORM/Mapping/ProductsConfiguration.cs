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
        builder.Property(u => u.Title).HasColumnType("varchar(100)");
        builder.Property(u => u.Price).HasColumnType("numeric");
        builder.Property(u => u.Description).HasColumnType("varchar(100)");
        builder.Property(u => u.Category).HasColumnType("varchar(100)");
        builder.Property(u => u.Image).HasColumnType("varchar(100)");
        builder.Property(u => u.RatingRate).HasColumnType("numeric");
        builder.Property(u => u.RatingCount).HasColumnType("int");

        builder.Property(u => u.CreatedAt).HasColumnType("date");
        builder.Property(u => u.UpdatedAt).HasColumnType("date");

        builder.HasOne<Carts>(u => u.Carts)
            .WithMany(u => u.Products);


    }
}
