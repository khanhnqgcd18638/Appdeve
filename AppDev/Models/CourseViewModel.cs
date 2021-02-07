using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDev.Models
{
    public class CourseViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
        public Category Category { get; set; }

    }
}