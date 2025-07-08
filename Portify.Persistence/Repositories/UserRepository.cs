using Microsoft.EntityFrameworkCore;
using Portify.Domain.Entities;
using Portify.Domain.Interfaces;
using Portify.Persistence.Data.Context;

namespace Portify.Persistence.Repositories;

public class UserRepository(PortifyDbContext db) : IUserRepository
{
    public async Task<User?> GetByGitHubIdAsync(int gitHubId)
        => await db.Users.FirstOrDefaultAsync(u => u.GitHubId == gitHubId);

    public async Task UpsertAsync(User user)
    {
        User? existing = await db.Users.FirstOrDefaultAsync(u => u.GitHubId == user.GitHubId);
        if (existing is null)
        {
            db.Users.Add(user);
        }
        else
        {
            typeof(User).GetProperty("Id")?.SetValue(user, existing.Id);
            db.Entry(existing).CurrentValues.SetValues(user);
        }
        await db.SaveChangesAsync();
    }
}
