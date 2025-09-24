using System.ComponentModel.DataAnnotations;
using education.Models;

namespace education.ViewModel
{
    public class ReviewAdd
    {
        public string Comment { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        public ReviewTargetType TargetType { get; set; }
        public int? LessonId { get; set; }
        public string InstructorId { get; set; }
    }
}
