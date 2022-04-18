using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsy.RedisCore.Test.Models
{
    class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees");
            builder.Property(p => p.EmpNo)
                .HasColumnName("emp_no")
                .HasColumnType("int(11)")
                .IsRequired();

            builder.HasKey(p => p.EmpNo);

            builder.Property(p => p.BirthDate)
                .HasColumnName("birth_date")
                .HasColumnType("date").
                IsRequired();

            builder.Property(p => p.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("varchar(14)")
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasColumnName("last_name")
                .HasColumnType("varchar(16)")
                .IsRequired();

            builder.Property(p => p.Gender)
                .HasColumnName("gender")
                .HasColumnType("enum('M','F')")
                .IsRequired();

            builder.Property(p => p.HireDate)
                .HasColumnName("hire_date")
                .HasColumnType("date")
                .IsRequired();

            builder.HasMany(p => p.Managers)
                .WithOne(p => p.Employee)
                .HasForeignKey(p => p.EmpNo)
                .HasConstraintName("dept_manager_ibfk_1")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.DeptEmployees)
                .WithOne(p => p.Employee)
                .HasForeignKey(p => p.EmpNo)
                .HasConstraintName("dept_emp_ibfk_1")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Salaries)
                .WithOne(p => p.Employee)
                .HasForeignKey(p => p.EmpNo)
                .HasConstraintName("salaries_ibfk_1")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Titles)
                .WithOne(p => p.Employee)
                .HasForeignKey(p => p.EmpNo)
                .HasConstraintName("titles_ibfk_1")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
