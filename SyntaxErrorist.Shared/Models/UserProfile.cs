using System.ComponentModel.DataAnnotations;

namespace SyntaxErrorist.Shared.Models
{
    public class UserProfile : BaseEntity
    {

        [Required]
        public Guid Id { get; set; }

        [Required]
        public BasicInfo BasicInfo { get; set; }
        public string IdentityId { get; set; } = string.Empty;
        public ApplicationUser IdentityUser { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
        public virtual ICollection<UserProfile> FriendsList { get; set; } = new List<UserProfile>();
        public virtual ICollection<FriendRequest> FriendRequestsSent { get; set; } = new List<FriendRequest>();
        public virtual ICollection<FriendRequest> FriendRequestsReceived { get; set; } = new List<FriendRequest>();

    }
}
