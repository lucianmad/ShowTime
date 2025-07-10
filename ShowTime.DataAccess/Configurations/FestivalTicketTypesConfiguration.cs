using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Configurations;

public class FestivalTicketTypesConfiguration : IEntityTypeConfiguration<FestivalTicketType>
{
    public void Configure(EntityTypeBuilder<FestivalTicketType> builder)
    {
        builder.ToTable("FestivalTicketTypes");
        builder.HasKey(ftt => new {ftt.FestivalId, ftt.TicketTypeId});
        builder.Property(ftt => ftt.Price).IsRequired();
        builder.Property(ftt => ftt.Quantity).IsRequired();
        
        builder.HasOne(ftt => ftt.TicketType)
            .WithMany(t => t.FestivalTicketTypes)
            .HasForeignKey(ftt => ftt.TicketTypeId);
        
        builder.HasOne(ftt => ftt.Festival)
            .WithMany(f => f.FestivalTicketTypes)
            .HasForeignKey(ftt => ftt.FestivalId);
    }
}