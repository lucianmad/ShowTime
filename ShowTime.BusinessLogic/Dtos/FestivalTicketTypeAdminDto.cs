namespace ShowTime.BusinessLogic.Dtos;

public class FestivalTicketTypeAdminDto
{
    public int TicketTypeId { get; set; }
    public string TicketTypeName { get; set; } = string.Empty;
    public string? TicketTypeDescription { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public int BookedQuantity { get; set; }
    public int RemainingQuantity { get; set; }
}