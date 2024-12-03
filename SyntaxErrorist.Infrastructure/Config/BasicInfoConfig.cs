using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyntaxErrorist.Shared.Models;

namespace SyntaxErrorist.Infrastructure.Config
{
    public class BasicInfoConfig : IEntityTypeConfiguration<BasicInfo>
    {
        public void Configure(EntityTypeBuilder<BasicInfo> builder)
        {
            builder.HasNoKey();
        }
    }
}
