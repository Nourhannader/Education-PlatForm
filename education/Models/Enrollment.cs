using System.ComponentModel.DataAnnotations.Schema;

namespace education.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        
        public virtual StudentProfile Student { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        
        public virtual Course Course { get; set; }

        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
        public bool IsPaid { get; set; } = false;
    }
}
