namespace DbFirstDaily.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.StudentDetails",
                c => new
                    {
                        StudentDetailsId = c.Int(nullable: false),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentDetailsId)
                .ForeignKey("dbo.Students", t => t.StudentDetailsId)
                .Index(t => t.StudentDetailsId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentDetails", "StudentDetailsId", "dbo.Students");
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.StudentDetails", new[] { "StudentDetailsId" });
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            DropTable("dbo.Students");
            DropTable("dbo.StudentDetails");
            DropTable("dbo.Teachers");
            DropTable("dbo.Courses");
        }
    }
}
