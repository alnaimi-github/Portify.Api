using ErrorOr;

using Portify.Application.Interfaces;
using Portify.Domain.Entities;
using Portify.Domain.Interfaces;

namespace Portify.Infrastructure.Services;

/// <summary>
/// Service for user persistence and retrieval, following Clean Architecture and result pattern.
/// </summary>
public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<ErrorOr<User>> UpsertGitHubUserAsync(User user)
    {
        await userRepository.UpsertAsync(user);
        return user; // Success case
    }

    public async Task<ErrorOr<User>> GetByGitHubIdAsync(int gitHubId)
    {
        User? user = await userRepository.GetByGitHubIdAsync(gitHubId);
        return user is not null
            ? user // Success case
            : Error.Failure("User not found"); // Failure case
    }
}
