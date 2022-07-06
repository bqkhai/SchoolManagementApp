using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.ViewModels
{
    public class LoginViewModel
    {
        [Required, Display(Name = "Email")]
        public string Username { get; set; }

        [Required, Display(Name = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
