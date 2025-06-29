using Microsoft.EntityFrameworkCore;
using Portify.Domain.Entities;

namespace Portify.Persistence.Data.Context;

public sealed class PortifyDbContext(DbContextOptions<PortifyDbContext> options)
    : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Repository> Repositories => Set<Repository>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PortifyDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
