using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WPFMVVM.Data;

public partial class MvvmdataContext : DbContext
{
    public MvvmdataContext()
    {
    }

    public MvvmdataContext(DbContextOptions<MvvmdataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Newtable> Newtables { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MVVMData;Username=postgres;Password=1256");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Newtable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("newtable");

            entity.Property(e => e.Column2)
                .ValueGeneratedOnAdd()
                .HasColumnName("column2");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pk");

            entity.ToTable("users");

            entity.HasIndex(e => e.Login, "users_un").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(90)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(90)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
