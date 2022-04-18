using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsy.RedisCore.Test.Models
{
    class DeptManagerMap : IEntityTypeConfiguration<DeptManager>
    {
        public void Configure(EntityTypeBuilder<DeptManager> builder)
        {
            builder.ToTable("dept_manager");

            builder.Property(p => p.DeptNo)
                .HasColumnName("dept_no")
                .HasColumnType("char(4)")
                .IsRequired();

            builder.Property(p => p.EmpNo)
                .HasColumnName("emp_no")
                .HasColumnType("int(11)")
                .IsRequired();

            builder.Property(p => p.FromDate)
                .HasColumnName("from_date")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.ToDate)
                .HasColumnName("to_date")
                .HasColumnType("date")
                .IsRequired();

            builder.HasKey(p => new { p.EmpNo, p.DeptNo });


            builder.HasIndex(p => p.DeptNo).HasName("dept_no");
            builder.HasIndex(p => p.EmpNo).HasName("emp_no");

            builder.HasOne(p => p.Department)
                .WithMany(p => p.Managers)
                .HasForeignKey(p => p.DeptNo)
                .HasConstraintName("dept_manager_ibfk_2").OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Employee)
                .WithMany(p => p.Managers)
                .HasForeignKey(p => p.EmpNo)
                .HasConstraintName("dept_manager_ibfk_1").OnDelete(DeleteBehavior.Cascade);
        }
    }
}
