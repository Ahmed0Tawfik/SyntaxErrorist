using Microsoft.EntityFrameworkCore;

namespace SyntaxErrorist.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
    }
}
