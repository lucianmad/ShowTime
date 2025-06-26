namespace ShowTime.DataAccess.Models;

public class Artist
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Genre { get; set; } = String.Empty;
    public string Image { get; set; } = String.Empty;
    
    public ICollection<Lineup> Lineups { get; set; } = new List<Lineup>();
    public ICollection<Festival> Festivals { get; set; } = new List<Festival>();
}