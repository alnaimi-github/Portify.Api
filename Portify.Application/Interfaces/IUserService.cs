using ErrorOr;
using Portify.Domain.Entities;

namespace Portify.Application.Interfaces;

public interface IUserService
{
    Task<ErrorOr<User>> UpsertGitHubUserAsync(User user);
    Task<ErrorOr<User>> GetByGitHubIdAsync(int gitHubId);
}
