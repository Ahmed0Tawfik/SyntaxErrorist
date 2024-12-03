namespace SyntaxErrorist.Shared.Models
{
    public class FriendRequest
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public virtual UserProfile SenderProfile { get; set; }
        public Guid ReceiverId { get; set; }
        public virtual UserProfile ReceiverProfile { get; set; }
        public DateTime SentAt { get; set; }
    }
}
