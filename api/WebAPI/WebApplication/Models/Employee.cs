using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Employee
    {
        public int UserId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeRole { get; set; }
        public string Motto { get; set; }
        public string Hobbies { get; set; }
        public string Hometown { get; set; }
        public string PersonalBlog { get; set; }
        public string PhotoFileName { get; set; }


    }
}