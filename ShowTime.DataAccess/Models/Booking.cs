namespace ShowTime.DataAccess.Models;

public class Booking
{
    public int FestivalId { get; set; }
    public int UserId { get; set; }
    public int TicketTypeId { get; set; }
    
    public FestivalTicketType FestivalTicketType { get; set; } = null!;
    public Festival Festival { get; set; } = null!;
    public User User { get; set; } = null!;
}