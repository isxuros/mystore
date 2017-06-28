namespace MyStore.Migrations
{
    using MyStore.Domain.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyStore.Infra.Data.MyStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyStore.Infra.Data.MyStoreDbContext context)
        {
                    
            if (context.Departments.Count() == 0)
            {
                context.Departments.Add(
                    new Department { DepartmentName = "TMG" });
                context.Departments.Add(
                    new Department { DepartmentName = "BDG" });
                context.SaveChanges();
            }
        }
    }
}
