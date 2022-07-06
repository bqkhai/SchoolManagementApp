using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
