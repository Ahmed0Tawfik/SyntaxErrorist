using System.ComponentModel.DataAnnotations;

namespace SyntaxErrorist.Shared.Models
{
    public class Playlist : BaseEntity
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        public Guid UserProfileId { get; set; } 
        public UserProfile UserProfile { get; set; }
        public bool IsPublic { get; set; } = true;
        public virtual ICollection<Card> Cards { get; set; } = new List<Card>();





    }
}
