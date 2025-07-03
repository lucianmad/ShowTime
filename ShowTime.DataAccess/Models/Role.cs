namespace ShowTime.DataAccess.Models;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string? Description { get; set; }
    
    public ICollection<User> Users { get; set; } = new List<User>();
}