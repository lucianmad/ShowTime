namespace ShowTime.BusinessLogic.Dtos;

public class FestivalTicketTypeCreateDto
{
    public int FestivalId { get; set; }
    public int TicketTypeId { get; set; }
    public string TicketTypeName { get; set; } = string.Empty;
    public int Price { get; set; }
    public int Quantity { get; set; }
}