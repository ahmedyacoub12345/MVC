using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DbFirstDaily.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; } // Primary Key
        public string Name { get; set; }

        // Navigation Property
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}