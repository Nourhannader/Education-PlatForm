using System.ComponentModel.DataAnnotations.Schema;

namespace education.Models
{
    public class StudentProfile
    {
        [ForeignKey("User")]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }

        public DateTime? BirthDate { get; set; }
        public string Country { get; set; }

        // Navigation
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; } 
        public virtual ICollection<Follow> Follows { get; set; }
        public virtual ICollection<Result> Results { get; set; } 

    }
}
