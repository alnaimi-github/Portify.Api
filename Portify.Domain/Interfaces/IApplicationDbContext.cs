using Microsoft.EntityFrameworkCore;
using Portify.Domain.Entities;

namespace Portify.Domain.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Repository> Repositories { get; }

    DbSet<UserLink> UserLinks { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
