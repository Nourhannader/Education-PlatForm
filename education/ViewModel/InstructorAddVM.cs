using System.ComponentModel.DataAnnotations;
using education.Models;

namespace education.ViewModel
{
    public class InstructorAddVM
    {
        public string Id { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage ="Max Lenth is 100")]
        public string Title { get; set; }
        [Required]
        public string  Skills { get; set; }
        [Required]
        [Range(150,500,ErrorMessage ="Minmum Length is 150 and Maxmum Length is 500")]
        public string Bio { get; set; }
    }
}
