using ShowTime.DataAccess.Models;

namespace ShowTime.BusinessLogic.Dtos;

public class CountryGetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
}