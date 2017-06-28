using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infra.Data
{
    public class MyStoreDbContext
        :  DbContext
    {
        public MyStoreDbContext()
            : base("MyStoreConnection")
        {

            base.Configuration.ProxyCreationEnabled = false;
            base.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.ID)
                .Property(e => e.ID).HasColumnName("EmployeeId");
            modelBuilder.Entity<Employee>()
                .HasRequired(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);
            modelBuilder.Entity<Department>()
                .HasKey(d => d.ID)
                .Property(d => d.ID).HasColumnName("DepartmentId");
            
                
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
