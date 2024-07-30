using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDBExp.Models;

public partial class MvccoreContext : DbContext
{
    public MvccoreContext()
    {
    }

    public MvccoreContext(DbContextOptions<MvccoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Userdetail> Userdetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=HA-NB69\\SQLEXPRESS;Database=MVCCore;User Id = sa;Password = 12345;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Cityid).HasName("PK__CITY__EE8DC9FB4F5974C7");

            entity.ToTable("CITY");

            entity.Property(e => e.Cityid).HasColumnName("CITYID");
            entity.Property(e => e.Cityname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CITYNAME");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Custid).HasName("PK__CUSTOMER__3D9DDA31813642E4");

            entity.ToTable("CUSTOMER");

            entity.Property(e => e.Custid).HasColumnName("CUSTID");
            entity.Property(e => e.Custemail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CUSTEMAIL");
            entity.Property(e => e.Custmobile)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CUSTMOBILE");
            entity.Property(e => e.Custname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CUSTNAME");
        });

        modelBuilder.Entity<Userdetail>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__USERDETA__7B9E7F35B6A61187");

            entity.ToTable("USERDETAILS");

            entity.Property(e => e.Userid).HasColumnName("USERID");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.Gender)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GENDER");
            entity.Property(e => e.Resumefilename)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("RESUMEFILENAME");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
