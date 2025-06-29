using Microsoft.EntityFrameworkCore;
using Portify.Domain.Entities;
using Portify.Domain.Interfaces;

namespace Portify.Persistence.Data.Context;

public sealed class PortifyDbContext(DbContextOptions<PortifyDbContext> options)
    : DbContext(options), IApplicationDbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Repository> Repositories => Set<Repository>();
    public DbSet<UserLink> UserLinks => Set<UserLink>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PortifyDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
