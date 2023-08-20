using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentMangementApp.MVC.Data;

public partial class Course
{
    public int Id { get; set; }

    [Display(Name="Course Name")]

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public int? Credits { get; set; }
}
