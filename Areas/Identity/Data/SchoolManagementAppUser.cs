using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SchoolManagementApp.Enum;
using SchoolManagementApp.Models;

namespace SchoolManagementApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the SchoolManagementAppUser class
public class SchoolManagementAppUser : IdentityUser
{
    //[Key]
    //public int UserId { get; set; }

    //[Required]
    //public UserRole UserRole { get; set; }

    //public virtual Class? Class { get; set; }

    //public int ClassID { get; set; }

    //[Column(TypeName = "nvarchar(50)")]
    //[Required(ErrorMessage = "This field is required")]
    //[StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "Length must be between 5 to 50")]
    //public string? UserName { get; set; }

    //[Column(TypeName = "nvarchar(50)")]
    //[Required(ErrorMessage = "This field is required")]
    //[StringLength(maximumLength: 50, MinimumLength = 10, ErrorMessage = "Length must be between 10 to 50")]
    //public string? FullName { get; set; }

    //[Required(ErrorMessage = "This field is required")]
    //public string? Email { get; set; }

    //[Required(ErrorMessage = "This field is required")]
    //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
    //public DateTime DoB { get; set; }

    //[Column(TypeName = "nvarchar(250)")]
    //[Required(ErrorMessage = "This field is required")]
    //[StringLength(maximumLength: 250, MinimumLength = 5, ErrorMessage = "Length must be between 5 to 250")]
    //public string? Address { get; set; }

    //public bool? isDeleted { get; set; }

    //[Required(ErrorMessage = "This field is required")]
    //[DataType(DataType.Password)]
    //public string? Password { get; set; }

    //[Required(ErrorMessage = "This field is required")]
    //[DataType(DataType.Password)]
    //[Compare("Password", ErrorMessage = "The Password and ConfirmPassword fields must match")]
    //public string? ConfirmPassword { get; set; }

    //[Required(ErrorMessage = "This field is required")]
    //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
    //public DateTime CreatedDate { get; set; }
}

