using System.ComponentModel.DataAnnotations.Schema;

namespace education.Models
{
    public class FileResource
    {
        public int Id { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; } // pdf, video, etc.
        [ForeignKey("Lesson")]
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
