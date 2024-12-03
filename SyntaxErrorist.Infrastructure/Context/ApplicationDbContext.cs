using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SyntaxErrorist.Infrastructure.Config;
using SyntaxErrorist.Shared.Models;

namespace SyntaxErrorist.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUserConfig());
            modelBuilder.ApplyConfiguration(new UserProfileConfig());
            //modelBuilder.ApplyConfiguration(new BasicInfoConfig());
            modelBuilder.ApplyConfiguration(new PlaylistConfig());
            modelBuilder.ApplyConfiguration(new CardConfig());
            modelBuilder.ApplyConfiguration(new FriendRequestConfig());






            base.OnModelCreating(modelBuilder);
        }

    }
}
