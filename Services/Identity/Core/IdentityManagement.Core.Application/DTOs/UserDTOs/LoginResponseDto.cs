namespace IdentityManagement.Core.Application.DTOs.UserDTOs;

public class LoginResponseDto
{
    public TokenResponseDto Token { get; set; } = null!;

    public bool EmailConfirmed { get; set; }
}