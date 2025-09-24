using education.Models;
using education.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace education.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonRepository lessonRepository;
        private readonly UserManager<ApplicationUser> userManager;
        public LessonController(ILessonRepository lessonRepository, UserManager<ApplicationUser> userManager)
        {
            this.lessonRepository = lessonRepository;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
