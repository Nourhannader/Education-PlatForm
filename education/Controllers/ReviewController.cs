using System.Security.Claims;
using education.Models;
using education.Repository;
using education.ViewModel;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace education.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewRepository reviewRepository;
        public ReviewController(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }
        [Authorize(Roles ="Admin")]
        public IActionResult PendingReviews()
        {
            var reviews = reviewRepository.GetAll();
            return View();
        }
        [HttpPost]
        [RequireAntiforgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveReview(int reviewId)
        {
            await reviewRepository.ApproveReview(reviewId);
            await reviewRepository.Save();
            return RedirectToAction("PendingReviews");
        }
        [HttpPost]
        [RequireAntiforgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectReview(int reviewId)
        {
            await reviewRepository.RejectReview(reviewId);
            await reviewRepository.Save();
            return RedirectToAction("PendingReviews");
        }

        [HttpPost]
        [RequireAntiforgeryToken]
        [Authorize(Roles ="Student")]
        public async Task<IActionResult> AddReview(ReviewAdd review)
        {
            if (ModelState.IsValid)
            {
                var userId= User.FindFirstValue(ClaimTypes.NameIdentifier);
                var newReview = new Review
                {
                    Comment = review.Comment,
                    Rating = review.Rating,
                    StudentId = userId,
                    InstructorId = review.InstructorId,
                    LessonId = review.LessonId,
                    TargetType = review.TargetType
                };
                await reviewRepository.Insert(newReview);
                await reviewRepository.Save();
                return Json(new { success = true, message = "Review submitted, waiting for admin approval." });
            }
            return Json(new { success = false, message = "Invalid review data." });
        }

        [HttpPost]
        [RequireAntiforgeryToken]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var review = reviewRepository.GetById(reviewId);
            if (review != null)
            {
                await reviewRepository.Delete(reviewId);
                await reviewRepository.Save();
                return Json(new { success = true, message = "Review deleted." });
            }
            return Json(new { success = false, message = "Review not found or you don't have permission to delete it." });
        }

        public IActionResult ReviewsByTarget(int targetId, ReviewTargetType targetType)
        {
            var reviews = reviewRepository.GetReviewsByTarget(targetId, targetType);
            var result =reviews.Select(r => new
            {
                r.Id,
                r.Comment,
                r.Rating,
                StudentName = r.Student.User.firstName+' '+ r.Student.User.lastName,
                r.CreatedAt
            });
            return Json(new {success=true,data=result});
        }


    }
}
