using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsy.RedisCore.Test.Models
{
    class EmployeesContext:DbContext
    {
        private string _connString;
        public EmployeesContext(string connString)
        {
            _connString = connString;
        }
        protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL(_connString, providerOptions => providerOptions.CommandTimeout(60))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new SalaryMap());
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new DeptEmpMap());
            modelBuilder.ApplyConfiguration(new DepartmentMap());
            modelBuilder.ApplyConfiguration(new DeptManagerMap());
            modelBuilder.ApplyConfiguration(new TitleMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Salary> Salaries
        {
            get;set;
        }

        public DbSet<DeptManager> DeptManagers
        {
            get;set;
        }

        public DbSet<Department> Departments
        {
            get;set;
        }

        public DbSet<Employee> Employees
        {
            get;set;
        }

        public DbSet<Title> Titles
        {
            get;set;
        }

        public DbSet<DeptEmp> DeptEmps
        {
            get;set;
        }
    }
}
