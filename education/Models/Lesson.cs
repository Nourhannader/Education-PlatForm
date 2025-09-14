using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace education.Models
{
    public class Lesson
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        // Media
        public string VideoUrl { get; set; }
        public string PdfUrl { get; set; }

        // Foreign key to Course
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        // Navigation
        public virtual ICollection<Quiz> Quizzes { get; set; } 
        public virtual ICollection<Review> Reviews { get; set; } 
    }
}
