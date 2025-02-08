using BlogBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogBackend.Infrastructure.Persistence.EntityFramework.Configurations;

public class UserFavoritePostConfiguration : BaseEntityConfiguration<UserFavoritePost>
{
    public override void Configure(EntityTypeBuilder<UserFavoritePost> builder)
    {
        base.Configure(builder);

        builder.HasOne(ufp => ufp.Post)
            .WithMany(p => p.UserFavoritePosts)
            .HasForeignKey(ufp => ufp.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ufp => ufp.User)
            .WithMany(u => u.UserFavoritePosts)
            .HasForeignKey(ufp => ufp.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(ufp => new { ufp.PostId, ufp.UserId })
            .IsUnique();
    }
}
