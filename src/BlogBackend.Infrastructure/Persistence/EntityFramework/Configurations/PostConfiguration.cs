using BlogBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogBackend.Infrastructure.Persistence.EntityFramework.Configurations;

public class PostConfiguration : BaseEntityConfiguration<Post>
{
    public override void Configure(EntityTypeBuilder<Post> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.Slug)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(p => p.Content)
            .IsRequired();

        builder.Property(p => p.ThumbnailPath)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(p => p.IsFeatured)
            .HasDefaultValue(false);

        builder.Property(p => p.IsPublished)
            .HasDefaultValue(false);

        builder.Property(p => p.PublishedAt)
            .IsRequired(false);

        builder.Property(p => p.ReadingTimeInMinutes)
            .IsRequired();

        builder.HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Comments)
            .WithOne(c => c.Post)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(p => p.Likes)
            .WithOne(l => l.Post)
            .HasForeignKey(l => l.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.UserFavoritePosts)
            .WithOne(uf => uf.Post)
            .HasForeignKey(uf => uf.PostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
