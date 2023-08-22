using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentMangementApp.MVC.Data;

namespace StudentMangementApp.MVC.Models
{
    public class ClassEnrollmentViewModel
    {
        public Class? Class { get; set; }
        public List<StudentEnrollmentViewModel> Enrollments { get; set; } = new List<StudentEnrollmentViewModel>();
    }
}