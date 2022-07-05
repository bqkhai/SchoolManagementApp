using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementApp.Models
{
    public class School
    {
        [Key]
        public int SchoolID { get; set; }

        public ICollection<Department>? Departments { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string SchoolName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FoundedTime { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int Capacity { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "This field is required")]
        [StringLength(maximumLength: 250, MinimumLength = 5, ErrorMessage = "Length must be between 5 to 250")]
        public string Address { get; set; }
    }
}
