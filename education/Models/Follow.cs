using System.ComponentModel.DataAnnotations.Schema;

namespace education.Models
{
    public class Follow
    {
        public int Id { get; set; }
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public virtual StudentProfile Student { get; set; }
        [ForeignKey("Instructor")]
        public string InstructorId { get; set; }
        public virtual InstructorProfile Instructor { get; set; }

        public DateTime FollowedAt { get; set; } = DateTime.UtcNow;
    }
}
