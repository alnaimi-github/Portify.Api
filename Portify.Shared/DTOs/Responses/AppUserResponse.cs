namespace Portify.Shared.DTOs.Responses;

/// <summary>
/// API response DTO for authenticated user.
/// </summary>
public sealed record AppUserResponse(
    /// <summary>User name.</summary>
    string UserName,
    /// <summary>Email address.</summary>
    string Email,
    /// <summary>Avatar image URL.</summary>
    string AvatarUrl,
    /// <summary>Full name.</summary>
    string Name,
    /// <summary>JWT token.</summary>
    string Token
);
