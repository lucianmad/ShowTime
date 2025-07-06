using ShowTime.DataAccess.Models;

namespace ShowTime.BusinessLogic.Dtos;

public class CityCreateDto
{
    public string Name { get; set; } = String.Empty;
    public int CountryId { get; set; }
}