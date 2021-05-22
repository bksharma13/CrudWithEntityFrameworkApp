using CrudWithEntityFrameworkApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWithEntityFrameworkApp.Database
{
    class MyDbContext : DbContext
    {
        public MyDbContext(): base("name=MyDbConnectionString")
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext, Migrations.Configuration>("name=MyDbConnectionString"));
        }

        public DbSet<Detail> Details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
