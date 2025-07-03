using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Bookings");
        builder.HasKey(b => new {b.FestivalId, b.UserId});
        builder.Property(b => b.Price).IsRequired();
        
        builder.HasOne(b => b.TicketType)
            .WithMany(t => t.Bookings)
            .HasForeignKey(b => b.TicketTypeId);
    }
}