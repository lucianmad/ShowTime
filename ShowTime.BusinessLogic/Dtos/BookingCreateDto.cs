namespace ShowTime.BusinessLogic.Dtos;

public class BookingCreateDto
{
    public int UserId { get; set; }
    public int FestivalId { get; set; }
    public int TicketTypeId { get; set; }
}