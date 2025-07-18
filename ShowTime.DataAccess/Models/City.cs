namespace ShowTime.DataAccess.Models;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int CountryId { get; set; }
    
    public Country Country { get; set; } = null!;
    public ICollection<Festival> Festivals { get; set; } = new List<Festival>();
}