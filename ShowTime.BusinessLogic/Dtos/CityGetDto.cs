using ShowTime.DataAccess.Models;

namespace ShowTime.BusinessLogic.Dtos;

public class CityGetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int CountryId { get; set; }
    public Country Country { get; set; } = null!;
}