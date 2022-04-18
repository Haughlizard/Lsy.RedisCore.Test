using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsy.RedisCore.Test.Models
{
    class TitleMap : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("titles");

            builder.Property(p => p.Ttitle)
                .HasColumnName("title")
                .HasColumnType("varchar(50)")
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

            builder.HasKey(p => new { p.EmpNo, p.Ttitle, p.FromDate });

            builder.HasIndex(p => p.EmpNo).HasName("emp_no");

            builder.HasOne(p => p.Employee)
                .WithMany(p => p.Titles)
                .HasForeignKey(p => p.EmpNo)
                .HasConstraintName("titles_ibfk_1")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
