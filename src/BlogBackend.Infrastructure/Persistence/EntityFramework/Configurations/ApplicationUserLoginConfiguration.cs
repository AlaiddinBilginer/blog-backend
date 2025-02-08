using BlogBackend.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogBackend.Infrastructure.Persistence.EntityFramework.Configurations;

public class ApplicationUserLoginConfiguration : IEntityTypeConfiguration<ApplicationUserLogin>
{
    public void Configure(EntityTypeBuilder<ApplicationUserLogin> builder)
    {
        builder.HasKey(ul => new { ul.LoginProvider, ul.ProviderKey });

        builder.Property(ul => ul.LoginProvider)
            .HasMaxLength(128);

        builder.Property(ul => ul.ProviderKey)
            .HasMaxLength(128);
    }
}
