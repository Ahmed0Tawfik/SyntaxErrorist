using System.ComponentModel.DataAnnotations;

namespace SyntaxErrorist.Shared.Models
{
    public class Card : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid PlaylistId { get; set; }
        public Playlist Playlist { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]

        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
