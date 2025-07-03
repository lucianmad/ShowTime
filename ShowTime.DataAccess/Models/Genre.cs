namespace ShowTime.DataAccess.Models;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    
    public ICollection<Artist> Artists { get; set; } = new List<Artist>();
}