namespace ShowTime.DataAccess.Models;

public class FestivalTicketType
{
    public int FestivalId { get; set; }
    public int TicketTypeId { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    
    public Festival Festival { get; set; } = null!;
    public TicketType TicketType { get; set; } = null!;
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}