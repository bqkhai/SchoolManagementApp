using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.Models
{
    public class School
    {
        [Key]
        public int SchoolID { get; set; }

        public string SchoolName { get; set; }

        public DateTime FoundedTime { get; set; }

        public int Capacity { get; set; }

        public string Address { get; set; }
    }
}
