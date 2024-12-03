using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyntaxErrorist.Shared.Models;

namespace SyntaxErrorist.Infrastructure.Config
{
    public class PlaylistConfig : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.HasMany(pl => pl.Cards)
                   .WithOne(c => c.Playlist)
                   .HasForeignKey(c => c.PlaylistId);
        }
    }
}
