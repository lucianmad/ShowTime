namespace ShowTime.BusinessLogic.Dtos;

public class FestivalCreateDto
{
    public string Name { get; set; } = String.Empty;
    public string Location { get; set; } = String.Empty;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string SplashArt { get; set; } = String.Empty;
    public int Capacity { get; set; }
}