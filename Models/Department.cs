using SchoolManagementApp.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementApp.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        public virtual School? School { get; set; }

        public int SchoolID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public DepartmentName DepartmentName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedDate { get; set; }
    }
}
