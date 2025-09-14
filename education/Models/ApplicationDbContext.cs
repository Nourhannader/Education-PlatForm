using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace education.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<StudentProfile> StudentProfiles { get; set; }
        public DbSet<InstructorProfile> InstructorProfiles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<FileResource> FileResources { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Example: composite unique constraint (Student + Course) for Enrollment
            builder.Entity<Enrollment>()
                .HasIndex(e => new { e.StudentId, e.CourseId })
                .IsUnique();

            // Example: composite unique constraint (Student + Instructor) for Follow
            builder.Entity<Follow>()
                .HasIndex(f => new { f.StudentId, f.InstructorId })
                .IsUnique();

            builder.Entity<Message>()
              .HasOne(m => m.Sender)
              .WithMany(u => u.SentMessages)
              .HasForeignKey(m => m.SenderId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
