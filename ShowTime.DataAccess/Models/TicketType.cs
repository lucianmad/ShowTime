namespace ShowTime.DataAccess.Models;

public class TicketType
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string? Description { get; set; }
    
    public ICollection<FestivalTicketType> FestivalTicketTypes { get; set; } = new List<FestivalTicketType>();
}