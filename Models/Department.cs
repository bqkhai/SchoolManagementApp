using Microsoft.AspNetCore.Mvc;
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
        [Required(ErrorMessage = "Trường không được trống")]
        //[Remote("IsAlreadyExist", "Departments", HttpMethod = "POST", ErrorMessage = "Khoa đã tồn tại")]
        public DepartmentName DepartmentName { get; set; }

        [Display(Name = "Sức chứa")]
        [Required(ErrorMessage = "Trường không được trống")]
        public int Capacity { get; set; }

        [Display(Name = "Ngày tạo")]
        [Required(ErrorMessage = "Trường không được trống")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedDate { get; set; }
    }
}
