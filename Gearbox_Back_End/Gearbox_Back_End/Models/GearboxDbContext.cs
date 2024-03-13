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

    public virtual DbSet<Kategoriafajtak> Kategoriafajtaks { get; set; }

    public virtual DbSet<Kosar> Kosars { get; set; }

    public virtual DbSet<Kosarkapcsolat> Kosarkapcsolats { get; set; }

    public virtual DbSet<Termek> Termeks { get; set; }

    public virtual DbSet<Vasalasiadatok> Vasalasiadatoks { get; set; }

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

        modelBuilder.Entity<Kategoriafajtak>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kategoriafajtak");

            entity.HasIndex(e => e.KategoriaNev, "KategoriaNev").IsUnique();

            entity.Property(e => e.KategoriaNev).HasMaxLength(100);
        });

        modelBuilder.Entity<Kosar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kosar");

            entity.HasIndex(e => e.KosarId, "KosarId");

            entity.HasIndex(e => e.TermekId, "TermekId");

            entity.Property(e => e.TermekNev).HasMaxLength(65);

            entity.HasOne(d => d.KosarNavigation).WithMany(p => p.Kosars)
                .HasForeignKey(d => d.KosarId)
                .HasConstraintName("kosar_ibfk_6");

            entity.HasOne(d => d.Termek).WithMany(p => p.Kosars)
                .HasForeignKey(d => d.TermekId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("kosar_ibfk_7");
        });

        modelBuilder.Entity<Kosarkapcsolat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kosarkapcsolat");

            entity.HasIndex(e => e.VasarloId, "VasarloId");

            entity.HasOne(d => d.Vasarlo).WithMany(p => p.Kosarkapcsolats)
                .HasForeignKey(d => d.VasarloId)
                .HasConstraintName("kosarkapcsolat_ibfk_1");
        });

        modelBuilder.Entity<Termek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("termek");

            entity.HasIndex(e => e.KategoriaId, "KategoriaId");

            entity.Property(e => e.Kep).HasMaxLength(999);
            entity.Property(e => e.Meret).HasMaxLength(5);
            entity.Property(e => e.Nev).HasMaxLength(200);
            entity.Property(e => e.VanEraktaron).HasColumnName("VanERaktaron");

            entity.HasOne(d => d.Kategoria).WithMany(p => p.Termeks)
                .HasForeignKey(d => d.KategoriaId)
                .HasConstraintName("termek_ibfk_1");
        });

        modelBuilder.Entity<Vasalasiadatok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("vasalasiadatok");

            entity.HasIndex(e => e.KosarId, "KosarId");

            entity.HasIndex(e => e.VasarloId, "VasarloId");

            entity.Property(e => e.Megye).HasMaxLength(999);
            entity.Property(e => e.Telepules).HasMaxLength(999);
            entity.Property(e => e.UtcaHazszam).HasMaxLength(999);

            entity.HasOne(d => d.Kosar).WithMany(p => p.Vasalasiadatoks)
                .HasForeignKey(d => d.KosarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vasalasiadatok_ibfk_2");

            entity.HasOne(d => d.Vasarlo).WithMany(p => p.Vasalasiadatoks)
                .HasForeignKey(d => d.VasarloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vasalasiadatok_ibfk_1");
        });

        modelBuilder.Entity<Vasarlo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("vasarlo");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.HasIndex(e => e.Jogosultsag, "Jogosultsag");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FelhasznaloNev).HasMaxLength(65);
            entity.Property(e => e.Hash)
                .HasMaxLength(65)
                .HasColumnName("HASH");
            entity.Property(e => e.Telefonszam).HasMaxLength(15);

            entity.HasOne(d => d.JogosultsagNavigation).WithMany(p => p.Vasarlos)
                .HasForeignKey(d => d.Jogosultsag)
                .HasConstraintName("vasarlo_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
