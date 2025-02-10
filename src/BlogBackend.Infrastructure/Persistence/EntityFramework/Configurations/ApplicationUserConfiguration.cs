using BlogBackend.Domain.Identity;
using BlogBackend.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogBackend.Infrastructure.Persistence.EntityFramework.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.NormalizedUserName).IsUnique();
        
        builder.HasIndex(u => u.NormalizedEmail).IsUnique();

        builder.HasIndex(u => u.UserName).IsUnique();

        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.UserName)
            .IsRequired()
            .HasMaxLength(75);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(u => u.NormalizedUserName)
            .IsRequired()
            .HasMaxLength(75);

        builder.Property(u => u.NormalizedEmail)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(u => u.ConcurrencyStamp)
            .IsConcurrencyToken();

        builder.Property(u => u.PhoneNumber)
            .IsRequired(false)
            .HasMaxLength(20);

        builder.Property(u => u.Bio)
            .IsRequired(false)
            .HasMaxLength(1000);

        builder.Property(u => u.ProfilePicturePath)
            .IsRequired(false)
            .HasMaxLength(255);

        builder.Property(u => u.FullName)
            .HasConversion(u => u.ToString(), u => FullName.Create(u));

        builder.HasMany<ApplicationUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
        builder.HasMany<ApplicationUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
        builder.HasMany<ApplicationUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
        builder.HasMany<ApplicationUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

        builder.HasMany(u => u.Posts)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Comments)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Likes)
            .WithOne(l => l.User)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.UserFavoritePosts)
            .WithOne(ufp => ufp.User)
            .HasForeignKey(ufp => ufp.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.SocialMediaAccounts)
            .WithOne(sma => sma.User)
            .HasForeignKey(sma => sma.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("identity_users");
    }
}
