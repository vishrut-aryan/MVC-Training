using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiExp.Models;

public partial class WebApiContext : DbContext
{
    public WebApiContext()
    {
    }

    public WebApiContext(DbContextOptions<WebApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Userdetail> Userdetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=HA-NB69\\SQLEXPRESS;Database=WebAPI;User Id = sa;Password = 12345;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Userdetail>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__USERDETA__7B9E7F35618BC499");

            entity.ToTable("USERDETAILS");

            entity.Property(e => e.Userid).HasColumnName("USERID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Mobile)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MOBILE");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
