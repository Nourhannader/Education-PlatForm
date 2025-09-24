using education.Models;

namespace education.Repository
{
    public interface IReviewRepository : IRepository<Review>
    {
        IEnumerable<Review> GetReviewsByTarget(int targetId, ReviewTargetType targetType);
        Review GetById(int reviewId);
        Task Delete(int reviewId);
        Task ApproveReview(int reviewId);
        Task RejectReview(int reviewId);
    }
}
