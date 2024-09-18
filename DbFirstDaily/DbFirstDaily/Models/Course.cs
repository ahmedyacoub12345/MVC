using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DbFirstDaily.Models
{
    public class Course
    {
        public int CourseId { get; set; } // Primary Key
        public string CourseName { get; set; }

        // Foreign Key
        public int TeacherId { get; set; }

        // Navigation Property
        public virtual Teacher Teacher { get; set; }
    }
}