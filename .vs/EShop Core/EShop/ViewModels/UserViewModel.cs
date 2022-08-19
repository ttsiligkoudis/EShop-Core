using System.ComponentModel.DataAnnotations;
using EShop.Models;

namespace EShop.ViewModels
{
    public class UserViewModel
    {
        public UserDto User { get; set; }
        public CustomerDto Customer { get; set; }

        public UserViewModel()
        {
            User = new UserDto();
            Customer = new CustomerDto();
        }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "The passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public CustomerDto Customer { get; set; }
        public RegisterViewModel()
        {
            Customer = new CustomerDto()
            {
                Email = "randomText@email.com"
            };
        }
    }
}