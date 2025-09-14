using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace education.ViewModel
{
    public class LoginVM
    {
        [Required]
        public string UserNameOrEmail { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
