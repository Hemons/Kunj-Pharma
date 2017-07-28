namespace PMS.Service.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PMS.Model;
    using PMS.Service;

    internal sealed class Configuration : DbMigrationsConfiguration<PMS.Service.PMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PMS.Service.PMSContext context)
        {

            using (PMSContext db = new PMSContext())
            {
                PMSuser user = new PMSuser
                {
                    Id = new Guid("BF60FF99-0E9E-4E75-8B4F-5C70CBD3B4A0"),
                    CreatedBy = new Guid("BF60FF99-0E9E-4E75-8B4F-5C70CBD3B4A0"),
                    ModifiedBy = new Guid("BF60FF99-0E9E-4E75-8B4F-5C70CBD3B4A0"),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    DOB = new DateTime(1993, 6, 9),
                    Email = "rockyrite1@gmail.com",
                    IsDeleted = false,
                    Attempts = 0,
                    Name = "Admin",
                    IsLockedOut = false,
                    Password = "zuP6a34uqUYrC+umlF5fWg==",
                    Phone = "8905179900",
                    UserName = "Admin"
                };
                db.PMSuser.Add(user);
                db.SaveChanges();
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
