namespace ShowTime.DataAccess.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public int RoleId { get; set; }
    
    public Role Role { get; set; } = null!;
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public ICollection<Festival> Festivals { get; set; } = new List<Festival>();
}
