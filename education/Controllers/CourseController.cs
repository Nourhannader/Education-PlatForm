using education.Models;
using education.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace education.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository courseRepository;
        private readonly UserManager<ApplicationUser> userManager;
        public CourseController(ICourseRepository courseRepository, UserManager<ApplicationUser> userManager)
        {
            this.courseRepository = courseRepository;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var courses = courseRepository.GetAll();
            return View(courses);
        }

    }
}
