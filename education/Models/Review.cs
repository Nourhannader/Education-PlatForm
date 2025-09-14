using System.ComponentModel.DataAnnotations.Schema;

namespace education.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public bool IsApproved { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Who wrote the review
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public virtual StudentProfile Student { get; set; }

        public ReviewTargetType TargetType { get; set; }

        // Optional link to Instructor
        [ForeignKey("Instructor")]
        public string InstructorId { get; set; }
        public virtual InstructorProfile Instructor { get; set; }

        // Optional link to Lesson
        [ForeignKey("Lesson")]
        public int? LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
