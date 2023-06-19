using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APP_CRUD_EntityFramework.Models;

public partial class BdCrudcoreEfContext : DbContext
{
    public BdCrudcoreEfContext()
    {
    }

    public BdCrudcoreEfContext(DbContextOptions<BdCrudcoreEfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Idcargo).HasName("PK__CARGO__1B43683DCC7622BB");

            entity.ToTable("CARGO");

            entity.Property(e => e.Idcargo).HasColumnName("IDCARGO");
            entity.Property(e => e.DesCargo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DES_CARGO");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Idempleado).HasName("PK__EMPLEADO__E014C316D057ABA0");

            entity.ToTable("EMPLEADO");

            entity.Property(e => e.Idempleado).HasColumnName("IDEMPLEADO");
            entity.Property(e => e.EstEmp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EST_EMP");
            entity.Property(e => e.Idcargo).HasColumnName("IDCARGO");
            entity.Property(e => e.MailEmp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MAIL_EMP");
            entity.Property(e => e.NomEmp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOM_EMP");
            entity.Property(e => e.TelEmp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TEL_EMP");

            entity.HasOne(d => d.oCargo).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.Idcargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EMPLEADO__IDCARG__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
