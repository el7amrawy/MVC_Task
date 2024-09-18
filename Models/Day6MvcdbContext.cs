﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCTask.Models;

public partial class Day6MvcdbContext : DbContext
{
    public Day6MvcdbContext(DbContextOptions options ):base(options) { }
    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName).HasMaxLength(50);
            entity.Property(e => e.DepartmnetManager).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.DepartId).HasColumnName("Depart_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName).HasMaxLength(50);
            entity.Property(e => e.Job).HasMaxLength(50);
            entity.Property(e => e.Salary).HasColumnType("decimal(9, 2)");

            entity.HasOne(d => d.Depart).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartId)
                .HasConstraintName("FK_Employees_Departments");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
