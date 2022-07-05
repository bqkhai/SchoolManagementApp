using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementApp.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        public virtual Department? Department { get; set; }

        public int DepartmentID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This field is required")]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "Length must be between 2 to 25")]
        public string ClassName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedDate { get; set; }
    }
}
