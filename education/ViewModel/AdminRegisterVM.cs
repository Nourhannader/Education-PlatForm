using education.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace education.ViewModel
{
    public class AdminRegisterVM
    {
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Required, EmailAddress]
        [UniqueEmail]
        public string Email { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        public IFormFile image { get; set; }
    }
}
