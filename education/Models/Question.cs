using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace education.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public QuestionType Type { get; set; }
        public string OptionsJson { get; set; } // For MCQ
        public string CorrectAnswer { get; set; }
        [ForeignKey("Quiz")]
        public int QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }

        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; } 
    }
}

