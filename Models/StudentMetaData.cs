using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StudentMangementApp.MVC.Data
{
    public class StudentMetaData
    {
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Date Of Birth")]
        [Required]
        public DateTime? DateOfBirth { get; set; }
    }

    [ModelMetadataType(typeof(StudentMetaData))]
    public partial class Student { }
}