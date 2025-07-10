namespace ShowTime.BusinessLogic.Dtos;

public class FestivalBookingAdminDto
{
    public int FestivalId { get; set; }
    public string FestivalName { get; set; } =  String.Empty;
    
    public int TicketTypeId { get; set; }
    public string TicketTypeName { get; set; } =  String.Empty;
    
    public string UserEmail { get; set; } =   String.Empty;
    
    public int Price { get; set; }
}