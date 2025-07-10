using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Bookings");
        builder.HasKey(b => new {b.FestivalId, b.UserId, b.TicketTypeId});
        
        builder.HasOne(b => b.FestivalTicketType)
            .WithMany(ftt => ftt.Bookings)
            .HasForeignKey(b => new { b.FestivalId, b.TicketTypeId })
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(b => b.Festival)
            .WithMany(f => f.Bookings)
            .HasForeignKey(b => b.FestivalId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}