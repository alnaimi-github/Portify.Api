namespace Portify.Application.Users.DTOs;

public record AppUserDto(
    Guid Id,
    string UserName,
    string Email,
    string? AvatarUrl,
    string? Name,
    string? Bio,
    string? Location,
    string? Company,
    string? Blog
);
