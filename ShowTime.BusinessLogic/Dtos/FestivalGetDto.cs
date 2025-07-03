using ShowTime.DataAccess.Models;

namespace ShowTime.BusinessLogic.Dtos;

public class FestivalGetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int LocationId { get; set; }
    public Location? Location { get; set; } 
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string SplashArt { get; set; } = String.Empty;
    public int Capacity { get; set; }
}