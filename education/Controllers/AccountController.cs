using System.Threading.Tasks;
using education.Models;
using education.Services;
using education.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace education.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private SaveImage saveImage;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,SaveImage saveImage)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.saveImage = saveImage;
        }
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM userVM)
        {
            if (ModelState.IsValid)
            {
                string imageUrl=await saveImage.UploadImage(userVM.image);
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = userVM.UserName,
                    firstName = userVM.FirstName,
                    lastName = userVM.LastName,
                    PasswordHash = userVM.Password,
                    imageUrl=imageUrl,
                    Email = userVM.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, userVM.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, userVM.Role);
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

            }
            return View("Register", userVM);
        }

        #endregion
        #region register as admain
        [HttpGet]
        public IActionResult RegisterAdmin()
        {
            return View("RegisterAdmin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAdmin(AdminRegisterVM userVM)
        {
            if (ModelState.IsValid)
            {
                string imageUrl = await saveImage.UploadImage(userVM.image);
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = userVM.UserName,
                    firstName = userVM.FirstName,
                    lastName = userVM.LastName,
                    PasswordHash = userVM.Password,
                    imageUrl = imageUrl,
                    Email = userVM.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, userVM.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

            }
            return View("Register", userVM);
        }

        #endregion
        #region Login
        [HttpGet]
        public IActionResult LogIn()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginVM userVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user;
                if (userVM.UserNameOrEmail.Contains("@"))
                {
                    user = await userManager.FindByEmailAsync(userVM.UserNameOrEmail);
                }
                else
                {
                    user = await userManager.FindByNameAsync(userVM.UserNameOrEmail);
                }
                if (user != null)
                {
                    bool found = await userManager.CheckPasswordAsync(user, userVM.Password);
                    if (found)
                    {
                        await signInManager.SignInAsync(user, userVM.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Invalidd Account");
            }

            return View("Login", userVM);
        }
        #endregion
        #region logout
        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("LogIn");
        }
        #endregion

    }
}
