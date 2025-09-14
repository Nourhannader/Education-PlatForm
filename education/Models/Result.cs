using System.ComponentModel.DataAnnotations.Schema;

namespace education.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey("Quiz")]
        public int QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public virtual StudentProfile Student { get; set; }
    }
}
