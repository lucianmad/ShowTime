namespace ShowTime.DataAccess.Models;

public class Booking
{
    public int FestivalId { get; set; }
    public int UserId { get; set; }
    public int TicketTypeId { get; set; } 
    public int Price { get; set; }
    
    public TicketType TicketType { get; set; } = null!;
    public Festival Festival { get; set; } = null!;
    public User User { get; set; } = null!;
}