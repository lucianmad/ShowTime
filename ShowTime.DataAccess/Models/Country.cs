namespace ShowTime.DataAccess.Models;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;

    public ICollection<City> Cities { get; set; } = new List<City>();    
}