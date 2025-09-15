using Microsoft.AspNetCore.Identity;

namespace education.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string? imageUrl {  get; set; }
        public DateTime? Joined { get; set; } = DateTime.UtcNow;

        //navigation property
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Message> SentMessages { get; set; }
        public virtual ICollection<Message> ReceivedMessages { get; set; }

    }
}
