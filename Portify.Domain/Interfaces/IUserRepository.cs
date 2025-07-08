using Portify.Domain.Entities;

namespace Portify.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByGitHubIdAsync(int gitHubId);
    Task UpsertAsync(User user);
}
