using System.ComponentModel.DataAnnotations.Schema;

namespace education.Models
{
    public class StudentAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        
        public virtual Question Question { get; set; }
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public virtual StudentProfile Student { get; set; }
    }
}
