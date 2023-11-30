namespace IdentityManagement.Core.Application.DTOs.UserDTOs;

public class UserCreationDto
{
    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;
}