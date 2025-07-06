using System.ComponentModel.DataAnnotations;
using ShowTime.DataAccess.Models;

namespace ShowTime.BusinessLogic.Dtos;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = String.Empty;
    [Required]
    public string Password { get; set; } = String.Empty;
}