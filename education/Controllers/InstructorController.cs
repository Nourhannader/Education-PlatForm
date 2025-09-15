using System.Security.Claims;
using System.Threading.Tasks;
using education.Models;
using education.Repository;
using education.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace education.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository instructorRepository;
        private readonly UserManager<ApplicationUser> userManager;
        public InstructorController(IInstructorRepository instructorRepository , UserManager<ApplicationUser> userManager)
        {
            this.instructorRepository = instructorRepository;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var instructors = instructorRepository.GetAll();
            List < InstructorsGetAllVM > instructorsList = new List<InstructorsGetAllVM>();
            foreach (var instructor in instructors)
            {
                var user = userManager.FindByIdAsync(instructor.Id).Result;
                InstructorsGetAllVM instructorVM = new InstructorsGetAllVM()
                {
                    Id = instructor.Id,
                    FullName = user.firstName+" "+user.lastName,
                    ImageUrl = user.imageUrl,
                    Title = instructor.Title,
                    Skills = instructor.Skills,
                    Bio = instructor.Bio,
                    Joined = user.Joined,
                    CourseCount = instructor.Courses.Count(), // Replace with actual course count
                    AverageRating = instructor.Reviews.Sum<Review>(r => r.Rating) / instructor.Reviews.Count(), // Replace with actual average rating
                    FollowerCount = instructor.Followers.Count() // Replace with actual follower count
                };
                instructorsList.Add(instructorVM);
            }
            return View(instructors);
        }
        [Authorize(Roles = "Instructor")]
        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }
        [Authorize(Roles ="Instructor")]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add(InstructorAddVM instructorVM)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var instructor = new InstructorProfile
                {
                    Id = userId,
                    Title = instructorVM.Title,
                    Skills = instructorVM.Skills,
                    Bio = instructorVM.Bio
                };
                await instructorRepository.Insert(instructor);
                await instructorRepository.Save();
                return RedirectToAction("Index");
            }
            return View("Add", instructorVM);
        }

        [Authorize(Roles = "Instructor")]
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var instructor = await instructorRepository.GetById(userId);
            if (instructor == null)
            {
                return NotFound();
            }
            var instructorVM = new InstructorAddVM
            {
                Title = instructor.Title,
                Skills = instructor.Skills,
                Bio = instructor.Bio
            };
            return View("Edit", instructorVM);
        }
        [Authorize(Roles = "Instructor")]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(InstructorAddVM instructorVM)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var instructor = await instructorRepository.GetById(userId);
                if (instructor == null)
                {
                    return NotFound();
                }
                instructor.Title = instructorVM.Title;
                instructor.Skills = instructorVM.Skills;
                instructor.Bio = instructorVM.Bio;
                await instructorRepository.Update(instructor);
                await instructorRepository.Save();
                return RedirectToAction("Index");
            }
            return View("Edit", instructorVM);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
           await instructorRepository.Delete(id);
            await instructorRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
