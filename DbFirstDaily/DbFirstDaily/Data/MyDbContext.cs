using DbFirstDaily.Models;
using System.Data.Entity;

public class SchoolContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentDetails> StudentDetails { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // One-to-One Configuration
        modelBuilder.Entity<Student>()
            .HasKey(s => s.StudentId);

        modelBuilder.Entity<StudentDetails>()
            .HasKey(sd => sd.StudentDetailsId);

        modelBuilder.Entity<StudentDetails>()
            .HasRequired(sd => sd.Student)
            .WithRequiredDependent(s => s.StudentDetails);

        // One-to-Many Configuration
        modelBuilder.Entity<Teacher>()
            .HasKey(t => t.TeacherId);

        modelBuilder.Entity<Course>()
            .HasKey(c => c.CourseId);

        modelBuilder.Entity<Course>()
            .HasRequired(c => c.Teacher)
            .WithMany(t => t.Courses)
            .HasForeignKey(c => c.TeacherId);

        base.OnModelCreating(modelBuilder);
    }
}
