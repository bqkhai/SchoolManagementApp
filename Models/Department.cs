using SchoolManagementApp.Enum;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        public virtual School? School { get; set; }

        public int SchoolID { get; set; }

        public DepartmentName DepartmentName { get; set; }

        public int Capacity { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
