using ShowTime.BusinessLogic.Dtos;

namespace ShowTime.BusinessLogic.Abstractions;

public interface IUserService
{
    Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
    Task RegisterAsync(RegisterDto registerDto);
}