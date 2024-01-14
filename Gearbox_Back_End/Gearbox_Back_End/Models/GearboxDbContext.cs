using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Gearbox_Back_End.Models;

public partial class GearBoxDbContext : DbContext
{
    public GearBoxDbContext()
    {
    }

    public GearBoxDbContext(DbContextOptions<GearBoxDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Jogosultsagok> Jogosultsagoks { get; set; }

    public virtual DbSet<Kosar> Kosars { get; set; }

    public virtual DbSet<Termek> Termeks { get; set; }

    public virtual DbSet<Vasarlo> Vasarlos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=gearbox_webshop;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_hungarian_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Jogosultsagok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("jogosultsagok");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nev).HasMaxLength(45);
        });

        modelBuilder.Entity<Kosar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kosar");

            entity.HasIndex(e => e.TermekId, "TermekId");

            entity.HasIndex(e => e.VasarloId, "VasarloId");

            entity.Property(e => e.TermekNev).HasMaxLength(65);

            entity.HasOne(d => d.Termek).WithMany(p => p.Kosars)
                .HasForeignKey(d => d.TermekId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("kosar_ibfk_3");

            entity.HasOne(d => d.Vasarlo).WithMany(p => p.Kosars)
                .HasForeignKey(d => d.VasarloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("kosar_ibfk_2");
        });

        modelBuilder.Entity<Termek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("termek");

            entity.Property(e => e.Kep).HasColumnType("blob");
            entity.Property(e => e.Nev).HasMaxLength(200);
            entity.Property(e => e.VanEraktaron).HasColumnName("VanERaktaron");
        });

        modelBuilder.Entity<Vasarlo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("vasarlo");

            entity.HasIndex(e => e.Jogosultsag, "Jogosultsag");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Hash)
                .HasMaxLength(65)
                .HasColumnName("HASH");
            entity.Property(e => e.Jelszo).HasMaxLength(32);
            entity.Property(e => e.Keresztnev).HasMaxLength(65);
            entity.Property(e => e.Salt)
                .HasMaxLength(65)
                .HasColumnName("SALT");
            entity.Property(e => e.Vezeteknev).HasMaxLength(65);

            entity.HasOne(d => d.JogosultsagNavigation).WithMany(p => p.Vasarlos)
                .HasForeignKey(d => d.Jogosultsag)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vasarlo_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
