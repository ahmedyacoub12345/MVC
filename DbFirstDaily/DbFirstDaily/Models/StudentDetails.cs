using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DbFirstDaily.Models
{
    public class StudentDetails
    {
        public int StudentDetailsId { get; set; } // Primary Key
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        // Foreign Key
        public int StudentId { get; set; }

        // Navigation Property
        public virtual Student Student { get; set; }
    }
}