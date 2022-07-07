using SchoolManagementApp.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Vai trò")]
        public UserRole UserRole { get; set; }

        //[Required]
        [Display(Name = "Lớp")]
        public virtual Class? Class { get; set; }

        [Display(Name = "Lớp")]
        public int ClassID { get; set; }

        //public Department Department { get; set; }

        //public School School { get; set; }

        [Display(Name = "Tên tài khoản")]
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Trường không được trống")]
        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "Độ dài từ 5 - 50")]
        public string? UserName { get; set; }

        [Display(Name = "Họ tên")]
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Trường không được trống")]
        [StringLength(maximumLength: 50, MinimumLength = 10, ErrorMessage = "Độ dài từ 10 - 50")]
        public string? FullName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Trường không được trống")]
        [RegularExpression(("^\\S+@\\S+\\.\\S+$"), ErrorMessage = "Email không đúng")]
        public string? Email { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Trường không được trống")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DoB { get; set; }

        [Display(Name = "Địa chỉ")]
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Trường không được trống")]
        [StringLength(maximumLength: 250, MinimumLength = 5, ErrorMessage = "Độ dài từ 5 - 250")]
        public string? Address { get; set; }

        [Display(Name = "Đã xóa")]
        public bool isDeleted { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Trường không được trống")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Required(ErrorMessage = "Trường không được trống")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        public string? ConfirmPassword { get; set; }

        [Display(Name = "Ngày tạo")]
        [Required(ErrorMessage = "Trường không được trống")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedDate { get; set; }
    }
}
