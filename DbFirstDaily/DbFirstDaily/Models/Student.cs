using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DbFirstDaily.Models
{
    public class Student
    {
        public int StudentId { get; set; } // Primary Key
        public string Name { get; set; }

        // Navigation Property
        public virtual StudentDetails StudentDetails { get; set; }
    }
}