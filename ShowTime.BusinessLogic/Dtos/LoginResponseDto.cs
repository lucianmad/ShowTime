using ShowTime.DataAccess.Models;

namespace ShowTime.BusinessLogic.Dtos;

public class LoginResponseDto
{
    public string Email { get; set; } = String.Empty;
    public string RoleName { get; set; } = String.Empty;
}