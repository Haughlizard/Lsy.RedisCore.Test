using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsy.RedisCore.Test.Models
{
    class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("departments");
            builder.Property(p => p.DeptName)
                .HasColumnName("dept_name")
                .HasColumnType("varchar(40)")
                .IsRequired();

            builder.Property(p => p.DeptNo)
                .HasColumnName("dept_no")
                .HasColumnType("char(4)")
                .IsRequired();

            builder.HasKey(p => p.DeptNo);

            builder.HasIndex(p => p.DeptName)
                .HasName("dept_name").IsUnique();

            builder.HasMany(p => p.Managers)
                .WithOne(p => p.Department)
                .HasForeignKey(p => p.DeptNo)
                .HasConstraintName("dept_manager_ibfk_2")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.DeptEmployees)
                .WithOne(p => p.Department)
                .HasForeignKey(p => p.DeptNo)
                .HasConstraintName("dept_emp_ibfk_2")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
