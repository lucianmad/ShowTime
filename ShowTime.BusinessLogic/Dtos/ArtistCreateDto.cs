using ShowTime.DataAccess.Models;

namespace ShowTime.BusinessLogic.Dtos;

public class ArtistCreateDto
{
    public string Name { get; set; } = String.Empty;
    public int GenreId { get; set; } 
    public string Image { get; set; } = String.Empty;
}