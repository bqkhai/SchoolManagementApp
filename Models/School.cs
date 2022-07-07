using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementApp.Models
{
    public class School
    {
        [Key]
        public int SchoolID { get; set; }

        public ICollection<Department>? Departments { get; set; }

        [Required(ErrorMessage = "Trường không được trống")]
        [Display(Name = "Tên trường")]
        [Remote("IsAlreadyExist", "Schools", HttpMethod = "POST", ErrorMessage = "Tên trường đã tồn tại")]
        public string SchoolName { get; set; }

        [Required(ErrorMessage = "Trường không được trống")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Ngày thành lập")]
        public DateTime FoundedTime { get; set; }

        [Required(ErrorMessage = "Trường không được trống")]
        [Display(Name = "Sức chứa")]
        public int Capacity { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Trường không được trống")]
        [Display(Name = "Địa chỉ")]
        [StringLength(maximumLength: 250, MinimumLength = 5, ErrorMessage = "Độ dài từ 5 - 250")]
        public string Address { get; set; }
    }
}
