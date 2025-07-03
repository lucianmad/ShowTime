namespace ShowTime.DataAccess.Models;

public class Artist
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int GenreId { get; set; } 
    public string Image { get; set; } = String.Empty;
    
    public Genre? Genre { get; set; } = null!;
    public ICollection<Lineup> Lineups { get; set; } = new List<Lineup>();
    public ICollection<Festival> Festivals { get; set; } = new List<Festival>();
}