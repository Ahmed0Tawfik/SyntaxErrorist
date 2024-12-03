using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyntaxErrorist.Shared.Models;

namespace SyntaxErrorist.Infrastructure.Config
{
    public class CardConfig : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.Description)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(c => c.ImageUrl)
                .IsRequired();
        }
    }
}
