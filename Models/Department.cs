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
        [Display(Name = "Trường")]
        public virtual School? School { get; set; }

        [Display(Name = "Trường")]
        public int SchoolID { get; set; }

        [Display(Name = "Khoa")]
        [Required(ErrorMessage = "This field is required")]
        public DepartmentName DepartmentName { get; set; }

        [Display(Name = "Sức chứa")]
        [Required(ErrorMessage = "This field is required")]
        public int Capacity { get; set; }

        [Display(Name = "Ngày tạo")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedDate { get; set; }
    }
}
