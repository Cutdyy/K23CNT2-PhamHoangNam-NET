using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace day11.Models;

public partial class PhamHoangNam2301900074Context : DbContext
{
    public PhamHoangNam2301900074Context()
    {
    }

    public PhamHoangNam2301900074Context(DbContextOptions<PhamHoangNam2301900074Context> options)
        : base(options)
    {
    }

    public virtual DbSet<PhnEmployee> PhnEmployees { get; set; }

  //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //    => optionsBuilder.UseSqlServer("Server=CUTDY\\SQLEXPRESS;Database=PHamHoangNam_2301900074;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PhnEmployee>(entity =>
        {
            entity.HasKey(e => e.PhnEmpId).HasName("PK__PhnEmplo__D9E874E8EA08010B");

            entity.ToTable("PhnEmployee");

            entity.Property(e => e.PhnEmpId).ValueGeneratedNever();
            entity.Property(e => e.PhnEmpLevel).HasMaxLength(50);
            entity.Property(e => e.PhnEmpName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
