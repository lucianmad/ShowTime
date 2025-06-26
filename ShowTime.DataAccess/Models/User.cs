using ShowTime.DataAccess.Enums;

namespace ShowTime.DataAccess.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public RoleType Role { get; set; }
    
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public ICollection<Festival> Festivals { get; set; } = new List<Festival>();
}
