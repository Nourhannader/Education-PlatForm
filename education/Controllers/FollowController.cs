using System.Security.Claims;
using education.Models;
using education.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace education.Controllers
{
    public class FollowController : Controller
    {
        private readonly IFollowRepository followRepository;
        private readonly UserManager<ApplicationUser> userManager;
        public FollowController(IFollowRepository followRepository, UserManager<ApplicationUser> userManager)
        {
            this.followRepository = followRepository;
            this.userManager = userManager;
        }
        [Authorize(Roles ="Student")]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> toggleFollowAsync(string instructorId)
        {
            var userId=User
                .FindFirstValue(ClaimTypes.NameIdentifier);
            bool isFollowed= await followRepository.toggleFollow(userId, instructorId);
            await followRepository.Save();
            return Json(new {sucess=true,followed=isFollowed});
        }
    }
}
