using SchoolManagementApp.Enum;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public UserRole UserRole { get; set; }

        public Class? Class { get; set; }

        //public Department Department { get; set; }

        //public School School { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime DoB { get; set; }

        public string Address { get; set; }

        public bool isDeleted { get; set; }

        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
