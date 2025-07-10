namespace ShowTime.BusinessLogic.Dtos;

public class BookingGetDto
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public int FestivalId { get; set; }
    public string FestivalName { get; set; } = string.Empty;
    public string TicketTypeName { get; set; } = string.Empty;
    public int Price { get; set; }
}