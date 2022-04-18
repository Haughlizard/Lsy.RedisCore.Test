using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsy.RedisCore.Test.Models
{
    class SalaryMap : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder.ToTable("salaries");
            builder.Property(b => b.EmpNo).HasColumnName("emp_no").IsRequired().HasColumnType("int(11)");
            builder.Property(b => b.IntSalary).HasColumnName("salary").IsRequired().HasColumnType("int(11)");
            builder.Property(b => b.FromDate).HasColumnName("from_date").IsRequired().HasColumnType("date");
            builder.Property(b => b.ToDate).HasColumnName("to_date").IsRequired().HasColumnType("date");
            builder.HasIndex(p=>p.EmpNo);
            builder.HasKey(p => new { p.EmpNo,p.FromDate});

            builder.HasOne(p => p.Employee)
                .WithMany(p => p.Salaries)
                .HasForeignKey(p => p.EmpNo)
                .HasConstraintName("salaries_ibfk_1")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
