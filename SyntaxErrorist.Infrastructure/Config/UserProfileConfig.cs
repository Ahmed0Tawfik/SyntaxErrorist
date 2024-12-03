using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyntaxErrorist.Shared.Models;

namespace SyntaxErrorist.Infrastructure.Config
{
    public class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(up => up.Id);

            builder.OwnsOne(up => up.BasicInfo, bi =>
            {
                bi.Property(bi => bi.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();
                bi.Property(bi => bi.LastName)
                    .HasMaxLength(50)
                    .IsRequired();
                bi.Property(bi => bi.ProfilePictureUrl)
                    .IsRequired();
                bi.Property(bi => bi.Bio)
                    .HasMaxLength(255);

                builder.HasMany(up => up.Playlists)
                .WithOne(p => p.UserProfile)
                .HasForeignKey(p => p.UserProfileId);

                builder.HasMany(up => up.FriendsList);

                builder.HasMany(up => up.FriendRequests);
            });


        }
    }
}
