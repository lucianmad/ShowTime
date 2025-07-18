namespace ShowTime.DataAccess.Models;

public class Lineup
{
    public int FestivalId { get; set; }
    public int ArtistId { get; set; }
    public string Stage { get; set; } = String.Empty;
    public DateTime StartTime { get; set; }

    public Festival Festival { get; set; } = null!;
    public Artist Artist { get; set; } = null!;
}