using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstProject.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}