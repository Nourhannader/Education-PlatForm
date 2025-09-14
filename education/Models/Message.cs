using System.ComponentModel.DataAnnotations.Schema;

namespace education.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        [ForeignKey("Sender")]
        public string SenderId { get; set; }
        public virtual ApplicationUser Sender { get; set; }
        [ForeignKey("Receiver")]
        public string ReceiverId { get; set; }
        public virtual ApplicationUser Receiver { get; set; }
        [ForeignKey("Conversation")]
        public int ConversationId { get; set; }
        public virtual Conversation Conversation { get; set; }
    }
}
