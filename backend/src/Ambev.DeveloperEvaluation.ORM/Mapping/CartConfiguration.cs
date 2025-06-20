using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Carts");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Date).IsRequired();
        
        builder.HasOne(x => x.User)
                .WithMany(x => x.Carts)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(x => x.UserId);

        builder.HasMany(x => x.Products)
                .WithOne(x => x.Cart)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(x => x.CartId);
    }
}
