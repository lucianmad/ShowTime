using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(255);
        builder.Property(u => u.Password).IsRequired().HasMaxLength(255);
        builder.Property(u => u.Role).IsRequired();
        
        builder.HasIndex(u => u.Email).IsUnique();
        
        builder.HasMany(u => u.Festivals)
            .WithMany(f => f.Users)
            .UsingEntity<Booking>();
    }
}