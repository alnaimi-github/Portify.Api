using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portify.Domain.Entities;

namespace Portify.Infrastructure.Data.Configurations;

public sealed class RepositoryConfiguration : IEntityTypeConfiguration<Repository>
{
    public void Configure(EntityTypeBuilder<Repository> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .ValueGeneratedOnAdd();

        builder.Property(r => r.GitHubId)
            .IsRequired();

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(r => r.Description)
            .HasMaxLength(500);

        builder.Property(r => r.Language)
            .HasMaxLength(100);

        builder.Property(r => r.Stars)
            .HasDefaultValue(0);

        builder.Property(r => r.Forks)
            .HasDefaultValue(0);

        builder.Property(r => r.Private)
            .HasDefaultValue(false);

        builder.Property(r => r.ReadmeContent)
            .HasColumnType("TEXT");

        builder.Property(r => r.Technologies)
            .HasMaxLength(500);

        builder.Property(r => r.Url)
            .HasMaxLength(500);

        builder.Property(r => r.Homepage)
            .HasMaxLength(500);

        builder.Property(r => r.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(r => r.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(r => r.LastSync)
            .IsRequired(false);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
