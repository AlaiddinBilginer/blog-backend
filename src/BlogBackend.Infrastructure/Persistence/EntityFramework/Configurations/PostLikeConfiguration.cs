using BlogBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogBackend.Infrastructure.Persistence.EntityFramework.Configurations;

public class PostLikeConfiguration : BaseEntityConfiguration<PostLike>
{
    public override void Configure(EntityTypeBuilder<PostLike> builder)
    {
        base.Configure(builder);

        builder.HasOne(pl => pl.Post)
            .WithMany(p => p.Likes)
            .HasForeignKey(pl => pl.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pl => pl.User)
            .WithMany(u => u.Likes)
            .HasForeignKey(pl => pl.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(pl => new { pl.PostId, pl.UserId })
            .IsUnique();
    }
}
