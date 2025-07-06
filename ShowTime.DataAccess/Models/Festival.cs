namespace ShowTime.DataAccess.Models;

public class Festival
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int? CityId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string SplashArt { get; set; } = String.Empty;
    public int Capacity { get; set; }
    
    public City? City { get; set; } = null!;   
    
    public ICollection<Lineup> Lineups { get; set; } = new List<Lineup>();
    public ICollection<Artist> Artists { get; set; } = new List<Artist>();
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public ICollection<User> Users { get; set; } = new List<User>();
}