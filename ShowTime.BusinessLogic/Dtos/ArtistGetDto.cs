namespace ShowTime.BusinessLogic.Dtos;

public class ArtistGetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Genre { get; set; } = String.Empty;
    public string Image { get; set; } = String.Empty;
}