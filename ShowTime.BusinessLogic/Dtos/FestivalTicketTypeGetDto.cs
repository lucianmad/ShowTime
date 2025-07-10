namespace ShowTime.BusinessLogic.Dtos;

public class FestivalTicketTypeGetDto
{
    public int FestivalId { get; set; }
    public int TicketTypeId { get; set; }
    public string TicketTypeName { get; set; } = String.Empty;
    public int Price { get; set; }
    public int Quantity { get; set; }
    
}