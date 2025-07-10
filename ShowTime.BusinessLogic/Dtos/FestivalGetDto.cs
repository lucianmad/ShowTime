using ShowTime.DataAccess.Models;

namespace ShowTime.BusinessLogic.Dtos;

public class FestivalGetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int? CityId { get; set; }
    public City? City { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string SplashArt { get; set; } = String.Empty;
    public List<FestivalTicketTypeGetDto> FestivalTicketTypes { get; set; }

}