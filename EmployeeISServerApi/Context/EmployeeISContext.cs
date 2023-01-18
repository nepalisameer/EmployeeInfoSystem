using System;
using System.Collections.Generic;
using EmployeeInformationSystemApi.Models;
using EmployeeInformationSystemApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInformationSystemApi.Context;

public partial class EmployeeISContext : DbContext
{
    public EmployeeISContext()
    {

    }
    public EmployeeISContext(DbContextOptions<EmployeeISContext> options, IMyConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
    }
    public virtual DbSet<EmpQualification> EmpQualifications { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<QualificationList> QualificationLists { get; set; }
    public IMyConfiguration Configuration { get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(Configuration.GetConnectionString());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmpQualification>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeId, e.QId }).HasName("PK__EMP_QUAL__075DFA6F1C0A5D33");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpQualifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Emp_Emp_Q_FK");

            entity.HasOne(d => d.QIdNavigation).WithMany(p => p.EmpQualifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Quali_Emp_Q_FK");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__781228D9E07DF59C");

            entity.Property(e => e.Gender).IsFixedLength();
        });

        modelBuilder.Entity<QualificationList>(entity =>
        {
            entity.HasKey(e => e.QId).HasName("PK__Qualific__F4FD2B665229D33C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
