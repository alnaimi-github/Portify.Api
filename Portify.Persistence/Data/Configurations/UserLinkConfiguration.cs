using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portify.Domain.Entities;

namespace Portify.Persistence.Data.Configurations;

public sealed class UserLinkConfiguration : IEntityTypeConfiguration<UserLink>
{
    public void Configure(EntityTypeBuilder<UserLink> builder)
    {
        builder.HasKey(ul => ul.Id);

        builder.Property(ul => ul.Id)
            .ValueGeneratedOnAdd();

        builder.Property(ul => ul.UserId)
            .IsRequired();

        builder.Property(ul => ul.Platform)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(ul => ul.Url)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasIndex(ul => new { ul.UserId, ul.Platform })
            .IsUnique();
    }
}
