namespace CrudWithEntityFrameworkApp.Migrations
{
    using CrudWithEntityFrameworkApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CrudWithEntityFrameworkApp.Database.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CrudWithEntityFrameworkApp.Database.MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            IList<Detail> details = new List<Detail>();
            details.Add(new Detail()
            {
                Fname = "User1", Lname = "User1.1", Age=21, Address="I do not know1", Dob=new DateTime(1970,10,10)
            });

            details.Add(new Detail()
            {
                Fname = "User2",
                Lname = "User2.1",
                Age = 22,
                Address = "I do not know2",
                Dob = new DateTime(1969, 10, 10)
            });

            details.Add(new Detail()
            {
                Fname = "User3",
                Lname = "User3.1",
                Age = 23,
                Address = "I do not know3",
                Dob = new DateTime(1968, 10, 10)
            });

            foreach (var item in details)
            {
                context.Details.Add(item);
            }

            base.Seed(context);
        }
    }
}
