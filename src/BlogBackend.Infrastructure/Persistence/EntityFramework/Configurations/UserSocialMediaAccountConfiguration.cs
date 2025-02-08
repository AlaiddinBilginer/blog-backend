using BlogBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogBackend.Infrastructure.Persistence.EntityFramework.Configurations;

public class UserSocialMediaAccountConfiguration : BaseEntityConfiguration<UserSocialMediaAccount>
{
    public override void Configure(EntityTypeBuilder<UserSocialMediaAccount> builder)
    {
        base.Configure(builder);

        builder.HasOne(usma => usma.User)
            .WithMany(u => u.SocialMediaAccounts)
            .HasForeignKey(usma => usma.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(usma => usma.SocialMediaType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(usma => usma.Url)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasIndex(usma => new { usma.UserId, usma.SocialMediaType, usma.Url})
            .IsUnique();
    }
}
