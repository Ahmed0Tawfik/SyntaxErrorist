using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SyntaxErrorist.Shared.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public UserProfile UserProfile { get; set; }
    }
}
