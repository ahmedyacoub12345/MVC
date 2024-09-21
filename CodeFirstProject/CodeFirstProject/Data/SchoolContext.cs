using CodeFirstProject.Models;
using System.Collections.Generic;
using System.Data.Entity;

public class SchoolContext : DbContext
{
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
}