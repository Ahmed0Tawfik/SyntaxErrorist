using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SyntaxErrorist.Shared.Models
{
    public class ApplicationUser : IdentityUser 
    {
        public UserProfile UserProfile { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
