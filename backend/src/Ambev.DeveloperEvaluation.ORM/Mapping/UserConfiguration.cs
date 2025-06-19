using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
        
        builder.HasIndex(x => x.Username)
            .IsUnique();

        builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.HasIndex(x => x.Email)
            .IsUnique();
        builder.Property(u => u.Phone).HasMaxLength(20);

        builder.Property(u => u.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(u => u.Role)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.OwnsOne(o => o.Name)
            .Property(p => p.Firstname).IsRequired().HasMaxLength(50);
        builder.OwnsOne(o => o.Name)
            .Property(p => p.Lastname).IsRequired().HasMaxLength(50);

        builder.OwnsOne(o => o.Address)
            .Property(p => p.City).IsRequired().HasMaxLength(70);
        builder.OwnsOne(o => o.Address)
            .Property(p => p.Street).IsRequired().HasMaxLength(50);
        builder.OwnsOne(o => o.Address)
            .Property(p => p.Number).IsRequired().HasMaxLength(20);
        builder.OwnsOne(o => o.Address)
            .Property(p => p.Zipcode).IsRequired().HasMaxLength(16);

        builder.OwnsOne(o => o.Address)
            .OwnsOne(p => p.Geolocation)
                .Property(p => p.Lat).IsRequired().HasMaxLength(12);
        builder.OwnsOne(o => o.Address)
            .OwnsOne(p => p.Geolocation)
                .Property(p => p.Long).IsRequired().HasMaxLength(13);
    }
}
