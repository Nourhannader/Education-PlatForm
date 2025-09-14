using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace education.Models
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;
            string email = value.ToString();

            var userManager = (UserManager<ApplicationUser>)validationContext.GetService(typeof(UserManager<ApplicationUser>));
            if (userManager.Users.Any(u => u.Email == email))
            {
                return new ValidationResult("Email already exists");
            }

            return ValidationResult.Success;
        }
    }
}
