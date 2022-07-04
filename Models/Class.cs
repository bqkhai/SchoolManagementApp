using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        public virtual Department? Department { get; set; }

        public int DepartmentID { get; set; }

        public string ClassName { get; set; }

        public int Capacity { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
