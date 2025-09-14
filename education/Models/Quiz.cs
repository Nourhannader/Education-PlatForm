using System.ComponentModel.DataAnnotations.Schema;

namespace education.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsFinal { get; set; } = false; // Final course quiz or lesson quiz
        public int TotalDegree { get; set; }

        // Relation with Course OR Lesson
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
       
        public virtual Course Course { get; set; }
        [ForeignKey("Lesson")]
        public int? LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        // Navigation
        public virtual ICollection<Question> Questions { get; set; } 
    }
}
