namespace CodeFirstProject.Migrations
{
    using CodeFirstProject.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolContext context)
        {
            context.Subjects.AddOrUpdate(s => s.Name,
                new Subject { Name = "Mathematics" },
                new Subject { Name = "Science" },
                new Subject { Name = "History" }
            );

            context.SaveChanges(); // Ensure changes are saved
        }
    }
}
