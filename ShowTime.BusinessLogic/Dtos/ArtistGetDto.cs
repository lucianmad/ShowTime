using ShowTime.DataAccess.Models;

namespace ShowTime.BusinessLogic.Dtos;

public class ArtistGetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int GenreId { get; set; }
    public Genre? Genre { get; set; }
    public string Image { get; set; } = String.Empty;
}