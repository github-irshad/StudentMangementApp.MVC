using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMangementApp.MVC.Models
{
    public class UserProfileViewModel
    {
        public string? Name { get; internal set; }
        public string? EmailAddress { get; internal set; }
        public string? ProfileImage { get; internal set; }
    }
}