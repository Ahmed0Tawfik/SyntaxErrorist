using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SyntaxErrorist.Shared.Models;

namespace SyntaxErrorist.Infrastructure.Config
{
    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasOne(u => u.UserProfile)
                .WithOne(up => up.IdentityUser)
                .HasForeignKey<UserProfile>(up => up.IdentityId);

            
        }
    }
}
