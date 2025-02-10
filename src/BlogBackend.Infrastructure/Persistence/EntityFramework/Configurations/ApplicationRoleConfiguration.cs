using BlogBackend.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogBackend.Infrastructure.Persistence.EntityFramework.Configurations;

public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasIndex(r => r.NormalizedName)
            .HasDatabaseName("RoleNameIndex")
            .IsUnique();

        builder.Property(r => r.ConcurrencyStamp)
            .IsConcurrencyToken();

        builder.Property(r => r.Name)
            .HasMaxLength(100);

        builder.Property(r => r.NormalizedName)
            .HasMaxLength(100);

        builder.HasMany<ApplicationUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
        builder.HasMany<ApplicationRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();

        builder.ToTable("identity_roles");

    }
}
