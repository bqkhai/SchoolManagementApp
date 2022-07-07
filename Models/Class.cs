using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementApp.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        [Display(Name = "Khoa")]
        public virtual Department? Department { get; set; }

        [Display(Name = "Khoa")]
        public int DepartmentID { get; set; }

        [Display(Name = "Lớp")]
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Trường không được trống")]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "Độ dài từ 2 - 25")]
        [Remote("IsAlreadyExist", "Classes", HttpMethod = "POST", ErrorMessage = "Tên lớp đã tồn tại")]
        public string ClassName { get; set; }

        [Display(Name = "Sức chứa")]
        [Required(ErrorMessage = "Trường không được trống")]
        public int Capacity { get; set; }

        [Display(Name = "Ngày tạo")]
        [Required(ErrorMessage = "Trường không được trống")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedDate { get; set; }
    }
}
