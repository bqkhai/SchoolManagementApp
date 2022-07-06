using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required, Display(Name = "Email")]
        public string Username { get; set; }

        [Required, Display(Name = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, Display(Name = "Confirm Password"), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
