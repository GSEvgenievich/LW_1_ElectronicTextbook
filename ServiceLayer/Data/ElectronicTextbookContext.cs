﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Models;

namespace ServiceLayer.Data;

public partial class ElectronicTextbookContext : DbContext
{
    public ElectronicTextbookContext()
    {
    }

    public ElectronicTextbookContext(DbContextOptions<ElectronicTextbookContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lection> Lections { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<Theme> Themes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=mssql;Database=ispp2102;User Id=ispp2102;Password=2102;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lection>(entity =>
        {
            entity.Property(e => e.LectionName).HasMaxLength(50);

            entity.HasOne(d => d.Theme).WithMany(p => p.Lections)
                .HasForeignKey(d => d.ThemeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lections_Themes");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.Property(e => e.QuestionAnswer).HasMaxLength(100);
            entity.Property(e => e.QuestionText).HasMaxLength(100);

            entity.HasOne(d => d.Test).WithMany(p => p.Questions)
                .HasForeignKey(d => d.TestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Questions_Tests");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleName).HasMaxLength(20);
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasOne(d => d.Lection).WithMany(p => p.Tests)
                .HasForeignKey(d => d.LectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tests_Lections");
        });

        modelBuilder.Entity<Theme>(entity =>
        {
            entity.Property(e => e.ThemeName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserLogin)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
