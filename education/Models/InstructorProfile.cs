using System.ComponentModel.DataAnnotations.Schema;

namespace education.Models
{
    public class InstructorProfile
    {
        [ForeignKey("User")]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }

        public string Title { get; set; }
        public string Skills { get; set; } 
        public string Bio { get; set; }
        
        

        // Navigation
        public virtual ICollection<Course> Courses { get; set; } 
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Follow> Followers { get; set; }
    }
}
