namespace ShowTime.BusinessLogic.Dtos;

public class BookingFestivalAdminDto
{
    public int UserId { get; set; }
    public string UserEmail { get; set; } = string.Empty;
    public string TicketTypeName { get; set; } = string.Empty;
    public int Price { get; set; }
}