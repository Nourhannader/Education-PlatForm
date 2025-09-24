using education.Models;

namespace education.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext context;
        public ReviewRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task ApproveReview(int reviewId)
        {
           var review= await context.Reviews.FindAsync(reviewId);
            if(review !=null)
            {
                review.IsApproved = true;
            }

        }

        public async Task Delete(int reviewId)
        {
            var review = await context.Reviews.FindAsync(reviewId);
            if (review != null)
            {
                context.Reviews.Remove(review);
            }
        }

        public IEnumerable<Review> GetAll()
        {
            var reviews = context.Reviews.Where(r => !r.IsApproved);
            return reviews;
        }

        public Review GetById(int reviewId)
        {
            return context.Reviews.Find(reviewId);
        }

        public IEnumerable<Review> GetReviewsByTarget(int targetId, ReviewTargetType targetType)
        {
            var reviews = context.Reviews.Where(r => r.TargetType == targetType &&
            (
              (targetType == ReviewTargetType.Instructor && r.InstructorId == targetId.ToString()) ||
              (targetType == ReviewTargetType.Lesson && r.LessonId == targetId)
            ) && r.IsApproved);

            return reviews;
        }

        public async Task Insert(Review entity)
        {
           await context.Reviews.AddAsync(entity);
        }

        public async Task RejectReview(int reviewId)
        {
            var review = await context.Reviews.FindAsync(reviewId);
            if (review != null)
            {
                context.Reviews.Remove(review);
            }
        }

        public async Task Save()
        {
          await  context.SaveChangesAsync();
        }
    }
}
