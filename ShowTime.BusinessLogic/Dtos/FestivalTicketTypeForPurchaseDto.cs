namespace ShowTime.BusinessLogic.Dtos;

public class FestivalTicketTypeForPurchaseDto
{
    public int TicketTypeId { get; set; }
    public string TicketTypeName { get; set; } = string.Empty;
    public string? TicketTypeDescription { get; set; }
    public int Price { get; set; }
    public int AvailableQuantity { get; set; }
}