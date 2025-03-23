using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartsConfiguration : IEntityTypeConfiguration<Carts>
{
    public void Configure(EntityTypeBuilder<Carts> builder)
    {
        builder.ToTable("Carts");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(u => u.UserId).HasColumnType("uuid");
        builder.Property(u => u.Date).HasColumnType("date");
        builder.Property(u => u.CreatedAt).HasColumnType("date");
        builder.Property(u => u.UpdatedAt).HasColumnType("date");

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(u => u.UserId);

        builder.HasMany<Products>(u => u.Products)
            .WithOne(u => u.Carts);
    }
}
