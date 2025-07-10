namespace ShowTime.BusinessLogic.Dtos;

public class BookingUserHistoryDto
{
    public int FestivalId { get; set; }
    public string FestivalName { get; set; } = string.Empty;
    public string TicketTypeName { get; set; } = string.Empty;
    public int Price { get; set; }
}