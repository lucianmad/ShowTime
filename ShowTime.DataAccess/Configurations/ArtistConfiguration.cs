using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Configurations;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.ToTable("Artists");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name).IsRequired().HasMaxLength(255);
        
        builder.HasIndex(a => a.Name).IsUnique();

        builder.HasOne(a => a.Genre)
            .WithMany(g => g.Artists)
            .HasForeignKey(a => a.GenreId);
        
        builder.HasMany(a => a.Festivals)
            .WithMany(f => f.Artists)
            .UsingEntity<Lineup>();
    }
}