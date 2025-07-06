using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Configurations;

public class FestivalConfiguration : IEntityTypeConfiguration<Festival>
{
    public void Configure(EntityTypeBuilder<Festival> builder)
    {
        builder.ToTable("Festivals");
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Name).IsRequired().HasMaxLength(255);
        builder.Property(f => f.StartDate).IsRequired();
        builder.Property(f => f.EndDate).IsRequired();
        builder.Property(f => f.Capacity).IsRequired();
        
        builder.HasIndex(f => f.Name).IsUnique();

        builder.HasOne(f => f.City)
            .WithMany(c => c.Festivals)
            .HasForeignKey(f => f.CityId);
        
        builder.HasMany(f => f.Artists)
            .WithMany(a => a.Festivals)
            .UsingEntity<Lineup>();
        
        builder.HasMany(f => f.Users)
            .WithMany(u => u.Festivals)
            .UsingEntity<Booking>();
    }
}