using education.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace education.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleVM roleVM)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = roleVM.Name
                };
                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return View("Create");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);

                }
            }
            return View("Create",roleVM);
        }

    }
}
