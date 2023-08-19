using System;
using System.Collections.Generic;

namespace StudentMangementApp.MVC.Data;

public partial class Student
{
    public int Id { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public DateOnly? Dateofbirth { get; set; }
}
