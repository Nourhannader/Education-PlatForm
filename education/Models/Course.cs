using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace education.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public CourseCategory Category { get; set; } = CourseCategory.Skill;
        public decimal Price { get; set; }
        public bool IsPublished { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool isDeleted { get; set; }=false;

        // Instructor (owner)
        [Required]
        [ForeignKey("Instructor")]
        public string InstructorId { get; set; }
        public virtual InstructorProfile Instructor { get; set; }

        // Navigation
        public virtual ICollection<Lesson> Lessons { get; set; } 
        public virtual ICollection<Quiz> Quizzes { get; set; } 
        public virtual ICollection<Enrollment> Enrollments { get; set; } 
    }
}
